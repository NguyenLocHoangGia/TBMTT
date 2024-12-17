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

const Cell = styled.div<{ borderTop?: boolean; borderRight?: boolean; borderLeft?: boolean; borderBottom?: boolean }>`
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

const X = styled.span`
  font-size: 100px;
  color: #8e44ad;
  &::after {
    content: "X";
  }
`;

const O = styled.span`
  font-size: 100px;
  color: #8e44ad;
  &::after {
    content: "O";
  }
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

export function Game() {
  const [matrix, setMatrix] = useState<Array<Array<string | null>>>([
    [null, null, null],
    [null, null, null],
    [null, null, null],
  ]);
  const [popupMessage, setPopupMessage] = useState<string | null>(null);

  const { playerSymbol, setPlayerSymbol, setPlayerTurn, setGameStarted, isGameStarted } = useContext(gameContext);

  const checkGameState = (matrix: Array<Array<string | null>>) => {
    // Logic kiểm tra trạng thái game như trước
    return [false, false];
  };

  const updateGameMatrix = (column: number, row: number, symbol: "x" | "o") => {
    const newMatrix = [...matrix];

    if (newMatrix[row][column] === null) {
      newMatrix[row][column] = symbol;
      setMatrix(newMatrix);

      if (socketService.socket) {
        gameService.updateGame(socketService.socket, newMatrix);
        const [currentPlayerWon, otherPlayerWon] = checkGameState(newMatrix);

        if (currentPlayerWon && otherPlayerWon) {
          setPopupMessage("Trò chơi hòa! Không ai thắng.");
        } else if (currentPlayerWon && !otherPlayerWon) {
          setPopupMessage("Chúc mừng! Bạn đã thắng.");
        } else if (!currentPlayerWon && otherPlayerWon) {
          setPopupMessage("Rất tiếc! Bạn đã thua.");
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

  useEffect(() => {
    handleGameUpdate();
  }, []);

  return (
    <GameContainer>
      {!isGameStarted && <h2>Chờ người chơi khác tham gia...</h2>}
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

      {/* Popup Modal */}
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
