import { Socket } from "socket.io-client";
import { IPlayMatrix, IStartGame } from "../../components/game/index";

class GameService {
  public async joinGameRoom(socket: Socket, roomId: string): Promise<boolean> {
    return new Promise((rs, rj) => {
      socket.emit("join_game", { roomId });
      socket.on("room_joined", () => rs(true));
      socket.on("room_join_error", ({ error }) => rj(error));
    });
  }

  public startNewGame(socket: Socket): void {
    if (socket) {
      socket.emit("startNewGame"); // Emit sự kiện tới server
    }
  }

  public async updateGame(socket: Socket, gameMatrix: IPlayMatrix) {
    socket.emit("update_game", { matrix: gameMatrix });
  }
  
  public async onGameUpdate(
    socket: Socket,
    listiner: (matrix: IPlayMatrix) => void
  ) {
    socket.on("on_game_update", ({ matrix }) => listiner(matrix));
  }
  

  public async onStartGame(
    socket: Socket,
    listiner: (options: IStartGame) => void
  ) {
    socket.on("start_game", listiner);
  }

  public async gameWin(socket: Socket, message: string) {
    socket.emit("game_win", { message });
  }
  public async gameLost(socket: Socket, message: string) {
    socket.emit("game_lost", { message });
  }

  public async onGameWin(socket: Socket, listiner: (message: string) => void) {
    socket.on("on_game_win", ({ message }) => listiner(message));
  }

  public async onGameLost(socket: Socket, listiner: (message: string) => void) {
    socket.on("on_game_lost", ({ message }) => listiner(message));
  }

  public sendMessage(socket: Socket, roomId: string, message: string) {
    socket.emit("send_message", { roomId, message });
  }
  
  public onReceiveMessage(socket: Socket, listener: (data: { message: string; sender: string }) => void) {
    socket.on("receive_message", listener);
  }
  
}

export default new GameService();
