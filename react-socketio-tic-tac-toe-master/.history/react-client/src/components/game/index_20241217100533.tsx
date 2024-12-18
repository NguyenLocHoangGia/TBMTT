import React, { useContext, useEffect, useState } from "react";
import styled from "styled-components";
import gameContext from "../../gameContext";
import gameService from "../../services/gameService";
import socketService from "../../services/socketService";

const GameContainer = styled.div`
  display: flex;
  flex-direction: column;
  font-family: "Zen Tokyo Zoo", cursive;
  position: relative;
`;

const RowContainer = styled.div`
  width: 100%;
  display: flex;
`;

interface ICellProps {
  borderTop?: boolean;
  borderRight?: boolean;
  borderLeft?: boolean;
  borderBottom?: boolean;
}

const Cell = styled.div<ICellProps>`
  width: 13em;
  height: 9em;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 20px;
  cursor: pointer;
  border-top: ${({ borderTop }) => borderTop && "3px solid #8e44ad"};
  border-left: ${({ borderLeft }) => borderLeft && "3px solid #8e44ad"};
  border-bottom: ${({ borderBottom }) => borderBottom && "3px solid #8e44ad"};
  border-right: ${({ borderRight }) => borderRight && "3px solid #8e44ad"};
  transition: all 270ms ease-in-out;

  &:hover {
    background-color: #8d44ad28;
  }
`;

const PlayStopper = styled.div`
  width: 100%;
  height: 100%;
  position: absolute;
  bottom: 0;
  left: 0;
  z-index: 99;
  cursor: default;
`;

const X = styled.span`
  font-size: 100px;
  color: #8e44ad;
  font-weight: bold;
`;

const O = styled.span`
  font-size: 100px;
  color: #8e44ad;
  font-weight: bold;
`;

const PopupOverlay = styled.div`
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
`;

const PopupContent = styled.div`
  background: #fff;
  padding: 2em;
  border-radius: 10px;
  text-align: center;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
  font-family: "Roboto", sans-serif;
`;

const Button = styled.button`
  background-color: #8e44ad;
  color: #fff;
  border: none;
  border-radius: 5px;
  padding: 10px 20px;
  font-size: 1rem;
  margin-top: 1em;
  cursor: pointer;

  &:hover {
    background-color: #732d91;
  }
`;

export type IPlayMatrix = Array<Array<string | null>>;
export interface IStartGame {
  start: boolean;
  symbol: "x" | "o";
}

export function Game() {
  const [matrix, setMatrix] = useState<IPlayMatrix>([
    [null, null, null],
    [null, null, null],
    [null, null, null],
  ]);
  const [popupMessage, setPopupMessage] = useState<string | null>(null);

  const {
    playerSymbol,
    setPlayerSymbol,
    setPlayerTurn,
    isPlayerTurn,
    setGameStarted,
    isGameStarted,
  } = useContext(gameContext);

  // Hàm kiểm tra trạng thái trò chơi
  const checkGameState = (matrix: IPlayMatrix): [boolean, boolean] => {
    // Kiểm tra hàng ngang
    for (let i = 0; i < 3; i++) {
      if (matrix[i].every((cell) => cell === playerSymbol)) return [true, false];
    }
    // Kiểm tra cột dọc
    for (let i = 0; i < 3; i++) {
      if (matrix.every((row) => row[i] === playerSymbol)) return [true, false];
    }
    // Kiểm tra đường chéo
    if (
      matrix[0][0] === playerSymbol &&
      matrix[1][1] === playerSymbol &&
      matrix[2][2] === playerSymbol
    )
      return [true, false];

    if (
      matrix[0][2] === playerSymbol &&
      matrix[1][1] === playerSymbol &&
      matrix[2][0] === playerSymbol
    )
      return [true, false];

    // Kiểm tra hòa
    if (matrix.every((row) => row.every((cell) => cell !== null))) {
      return [true, true]; // Hòa
    }

    return [false, false]; // Trò chơi tiếp tục
  };

  const updateGameMatrix = (column: number, row: number, symbol: "x" | "o") => {
    const newMatrix = [...matrix];

    if (newMatrix[row][column] === null || newMatrix[row][column] === "null") {
      newMatrix[row][column] = symbol;
      setMatrix(newMatrix);

      if (socketService.socket) {
        gameService.updateGame(socketService.socket, newMatrix);
        const [currentPlayerWon, isDraw] = checkGameState(newMatrix);

        if (currentPlayerWon && isDraw) {
          gameService.gameWin(socketService.socket, "The Game is a TIE!");
          setPopupMessage("Trò chơi hòa! Không ai thắng.");
        } else if (currentPlayerWon) {
          gameService.gameWin(socketService.socket, "You Won!");
          setPopupMessage("Chúc mừng! Bạn đã thắng.");
        }

        setPlayerTurn(false);
      }
    }
  };

  const handleGameUpdate = () => {
    if (socketService.socket)
      gameService.onGameUpdate(socketService.socket, (newMatrix) => {
        setMatrix(newMatrix);
        setPlayerTurn(true);
      });
  };

  const handleGameStart = () => {
    if (socketService.socket)
      gameService.onStartGame(socketService.socket, (options) => {
        setGameStarted(true);
        setPlayerSymbol(options.symbol);
        setPlayerTurn(options.start);
      });
  };

  useEffect(() => {
    handleGameUpdate();
    handleGameStart();
  }, []);

  return (
    <GameContainer>
      {!isGameStarted && <h2>Chờ người chơi khác tham gia...</h2>}
      {(!isGameStarted || !isPlayerTurn) && <PlayStopper />}
      {matrix.map((row, rowIdx) => (
        <RowContainer key={rowIdx}>
          {row.map((column, columnIdx) => (
            <Cell
              key={`${rowIdx}-${columnIdx}`}
              borderRight={columnIdx < 2}
              borderLeft={columnIdx > 0}
              borderBottom={rowIdx < 2}
              borderTop={rowIdx > 0}
              onClick={() => updateGameMatrix(columnIdx, rowIdx, playerSymbol)}
            >
              {column === "x" ? <X /> : column === "o" ? <O /> : null}
            </Cell>
          ))}
        </RowContainer>
      ))}

      {/* Popup hiển thị kết quả */}
      {popupMessage && (
        <PopupOverlay>
          <PopupContent>
            <h2>{popupMessage}</h2>
            <Button onClick={() => setPopupMessage(null)}>Đóng</Button>
          </PopupContent>
        </PopupOverlay>
      )}
    </GameContainer>
  );
}
