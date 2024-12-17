import React, { useContext, useState } from "react";
import styled from "styled-components";
import gameContext from "../../gameContext";
import gameService from "../../services/gameService";
import socketService from "../../services/socketService";

interface IJoinRoomProps {}

const JoinRoomContainer = styled.div`
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 2em;
  font-family: "Roboto", sans-serif;
`;

const Title = styled.h2`
  color: #2c3e50;
  margin-bottom: 1em;
`;

const RoomIdInput = styled.input`
  height: 40px;
  width: 22em;
  font-size: 16px;
  outline: none;
  border: 2px solid #3498db;
  border-radius: 6px;
  padding: 0 12px;
  margin-bottom: 1em;
  transition: all 0.3s ease;

  &:focus {
    border-color: #2980b9;
    box-shadow: 0 0 8px rgba(52, 152, 219, 0.4);
  }
`;

const JoinButton = styled.button`
  outline: none;
  background-color: #3498db;
  color: #fff;
  font-size: 16px;
  border: none;
  border-radius: 6px;
  padding: 10px 20px;
  transition: all 0.3s ease;
  cursor: pointer;

  &:hover {
    background-color: #2980b9;
    box-shadow: 0 4px 6px rgba(52, 152, 219, 0.2);
  }

  &:disabled {
    background-color: #95a5a6;
    cursor: not-allowed;
  }
`;

export function JoinRoom(props: IJoinRoomProps) {
  const [roomName, setRoomName] = useState("");
  const [isJoining, setJoining] = useState(false);

  const { setInRoom } = useContext(gameContext);

  const handleRoomNameChange = (e: React.ChangeEvent<any>) => {
    const value = e.target.value;
    setRoomName(value);
  };

  const joinRoom = async (e: React.FormEvent) => {
    e.preventDefault();

    const socket = socketService.socket;
    if (!roomName || roomName.trim() === "" || !socket) return;

    setJoining(true);

    const joined = await gameService
      .joinGameRoom(socket, roomName)
      .catch((err) => {
        alert("Đã có lỗi xảy ra: " + err);
      });

    if (joined) setInRoom(true);

    setJoining(false);
  };

  return (
    <form onSubmit={joinRoom}>
      <JoinRoomContainer>
        <Title>Tham Gia Phòng Chơi</Title>
        <RoomIdInput
          placeholder="Nhập mã phòng..."
          value={roomName}
          onChange={handleRoomNameChange}
        />
        <JoinButton type="submit" disabled={isJoining}>
          {isJoining ? "Đang tham gia..." : "Tham gia"}
        </JoinButton>
      </JoinRoomContainer>
    </form>
  );
}
