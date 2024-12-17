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
  width: 6em;
  height: 6em;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 10px;
  cursor: pointer;
  border: 2px solid #8e44ad;
  transition: all 270ms ease-in-out;

  &:hover {
    background-color: #e8d4f5;
  }
`;

const X = styled.span`
  font-size: 50px;
  color: #8e44ad;
  font-weight: bold;
`;

const O = styled.span`
  font-size: 50px;
  color: #3498db;
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

  const checkGameState = (matrix: IPlayMatrix) => {
    for (let i = 0; i < 3; i++) {
      if (matrix[i].every((v) => v === playerSymbol)) return [true, false];
      if (matrix.every((row) => row[i] === playerSymbol)) return [true, false];
    }
    if (
      matrix[0][0] === playerSymbol &&
      matrix[1][1] === playerSymbol &&
      matrix[2][2] === playerSymbol
    )
      return [true, false];
    if (
      matrix[2][0] === playerSymbol &&
      matrix[1][1] === playerSymbol &&
      matrix[0][2] === playerSymbol
    )
      return [true, false];
    return [false, false];
  };

  const updateGameMatrix = (column: number, row: number, symbol: "x" | "o") => {
    const newMatrix = [...matrix];

    if (newMatrix[row][column] === null) {
      newMatrix[row][column] = symbol;
      setMatrix(newMatrix);

      if (socketService.socket) {
        gameService.updateGame(socketService.socket, newMatrix);
        const [currentPlayerWon] = checkGameState(newMatrix);

        if (currentPlayerWon) {
          setPopupMessage("Chúc mừng! Bạn đã thắng.");
        } else if (newMatrix.every((row) => row.every((cell) => cell !== null))) {
          setPopupMessage("Trò chơi hòa! Không ai thắng.");
        }

        setPlayerTurn(false);
      }
    }
  };

  const handleGameUpdate = () => {
    if (socketService.socket) {
      gameService.onGameUpdate(socketService.socket, (newMatrix) => {
        setMatrix(newMatrix);
        setPlayerTurn(true);
      });
    }
  };

  const handleGameWin = () => {
    if (socketService.socket) {
      gameService.onGameWin(socketService.socket, (message) => {
        setPopupMessage(message);
        setPlayerTurn(false);
      });
    }
  };

  const handleGameStart = () => {
    if (socketService.socket) {
      gameService.onStartGame(socketService.socket, (options) => {
        setGameStarted(true);
        setPlayerSymbol(options.symbol);
        if (options.start) setPlayerTurn(true);
        else setPlayerTurn(false);
      });
    }
  };

  useEffect(() => {
    handleGameUpdate();
    handleGameStart();
    handleGameWin();
  }, []);

  return (
    <GameContainer>
      {!isGameStarted && <h2>Chờ người chơi khác tham gia...</h2>}
      {matrix.map((row, rowIdx) => (
        <RowContainer key={rowIdx}>
          {row.map((column, columnIdx) => (
            <Cell
              key={`${rowIdx}-${columnIdx}`}
              onClick={() => updateGameMatrix(columnIdx, rowIdx, playerSymbol)}
            >
              {column === "x" ? <X>X</X> : column === "o" ? <O>O</O> : null}
            </Cell>
          ))}
        </RowContainer>
      ))}

      {/* Popup thông báo */}
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
