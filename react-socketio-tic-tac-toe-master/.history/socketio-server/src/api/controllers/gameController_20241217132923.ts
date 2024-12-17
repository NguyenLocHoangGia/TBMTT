import {
  ConnectedSocket,
  MessageBody,
  OnMessage,
  SocketController,
  SocketIO,
} from "socket-controllers";
import { Server, Socket } from "socket.io";

@SocketController()
export class GameController {
  private getSocketGameRoom(socket: Socket): string {
    const socketRooms = Array.from(socket.rooms.values()).filter(
      (r) => r !== socket.id
    );
    const gameRoom = socketRooms && socketRooms[0];
    return gameRoom;
  }

  // Cập nhật game
  @OnMessage("update_game")
  public async updateGame(
    @SocketIO() io: Server,
    @ConnectedSocket() socket: Socket,
    @MessageBody() message: any
  ) {
    const gameRoom = this.getSocketGameRoom(socket);
    socket.to(gameRoom).emit("on_game_update", message);
  }

  // Sự kiện gửi tin nhắn
  @OnMessage("send_message")
public async sendMessage(
  @SocketIO() io: Server,
  @ConnectedSocket() socket: Socket,
  @MessageBody() { roomId, message, playerName }: { roomId: string; message: string; playerName: string }
) {
  console.log(`Message from ${playerName}: ${message} to room ${roomId}`);
  
  // Gửi thêm socket.id để phân biệt người gửi
  io.to(roomId).emit("receive_message", {
    message,
    sender: playerName,
    senderId: socket.id, // Thêm socket ID vào tin nhắn
  });
}  

  // Sự kiện thắng game
  @OnMessage("game_win")
  public async gameWin(
    @SocketIO() io: Server,
    @ConnectedSocket() socket: Socket,
    @MessageBody() message: any
  ) {
    const gameRoom = this.getSocketGameRoom(socket);
    socket.to(gameRoom).emit("on_game_win", message);
  }
}
