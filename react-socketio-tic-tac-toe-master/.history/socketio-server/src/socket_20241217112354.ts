import { useSocketServer } from "socket-controllers";
import { Server } from "socket.io";

export default (httpServer) => {
  const io = new Server(httpServer, {
    cors: {
      origin: "*", // Cho phép mọi domain kết nối
    },
  });

  // Khởi chạy controllers
  useSocketServer(io, { controllers: [__dirname + "/api/controllers/*.ts"] });

  return io;
};
