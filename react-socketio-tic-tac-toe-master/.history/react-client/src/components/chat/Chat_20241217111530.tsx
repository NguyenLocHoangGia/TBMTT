import React, { useState, useEffect, useContext } from "react";
import styled from "styled-components";
import socketService from "../../services/socketService";
import gameService from "../../services/gameService";
import gameContext from "../../gameContext";

const ChatContainer = styled.div`
  border: 2px solid #2980b9;
  border-radius: 10px;
  width: 300px;
  height: 400px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  margin-top: 1em;
`;

const MessagesContainer = styled.div`
  flex: 1;
  overflow-y: auto;
  padding: 10px;
  font-size: 14px;
`;

const InputContainer = styled.div`
  display: flex;
  padding: 10px;
  border-top: 1px solid #ddd;
`;

const Input = styled.input`
  flex: 1;
  padding: 5px;
  border: 1px solid #ddd;
  border-radius: 4px;
`;

const SendButton = styled.button`
  margin-left: 5px;
  background-color: #3498db;
  color: #fff;
  border: none;
  padding: 5px 10px;
  cursor: pointer;
  border-radius: 4px;

  &:hover {
    background-color: #2980b9;
  }
`;

const Chat = () => {
  const [messages, setMessages] = useState<{ message: string; sender: string }[]>([]);
  const [input, setInput] = useState("");
  const { isInRoom } = useContext(gameContext);

  useEffect(() => {
    const socket = socketService.socket;
    if (socket) {
      gameService.onReceiveMessage(socket, (data) => {
        setMessages((prevMessages) => [...prevMessages, data]);
      });
    }
  }, []);

  const sendMessage = () => {
    const socket = socketService.socket;
    if (socket && input.trim() && isInRoom) {
      gameService.sendMessage(socket, "your-room-id", input);
      setMessages((prev) => [...prev, { message: input, sender: "You" }]);
      setInput("");
    }
  };

  return (
    <ChatContainer>
      <MessagesContainer>
        {messages.map((msg, idx) => (
          <div key={idx}>
            <strong>{msg.sender}:</strong> {msg.message}
          </div>
        ))}
      </MessagesContainer>
      <InputContainer>
        <Input
          value={input}
          onChange={(e) => setInput(e.target.value)}
          placeholder="Gửi tin nhắn..."
        />
        <SendButton onClick={sendMessage}>Gửi</SendButton>
      </InputContainer>
    </ChatContainer>
  );
};

export default Chat;
