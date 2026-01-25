using System;
using System.Collections.Generic;

namespace Ex05.Logic
{


    public class GameManager
    {
        private Board m_Board;
        private List<Player> m_Players;
        private eGameMode m_GameMode;
        private bool m_IsGameOver;
        private readonly Random r_Random;
        private Player m_CurrentPlayer;

        public event Action<Player> GameOver;
        public event Action<int, int, char> UpdateBoard;
        public event Action ClearBoard;
        public event Action<Player> UpdateScore;
        public event Action<int> ColumnFull;

        public GameManager(GameManagerCreationParameters i_CreationParameters)
        {
            if(i_CreationParameters == null)
            {
                throw new ArgumentNullException("i_CreationParameters cannot be null");
            }

            r_Random = new Random();
            m_Board = new Board(i_CreationParameters.BoardHeight, i_CreationParameters.BoardWidth);
            m_Board.UpdateBoard += board_UpdateBoard;
            m_Board.ColumnFull += board_ColumnFull;
            m_GameMode = i_CreationParameters.GameMode;
            initializePlayers(i_CreationParameters.Player1Name, i_CreationParameters.Player2Name);
        }

        private void board_ColumnFull(int i_Column)
        {
            OnColumnFull(i_Column);
        }

        protected virtual void OnColumnFull(int i_Column)
        {
            if(ColumnFull != null)
            {
                ColumnFull.Invoke(i_Column);
            }
        }

        private void initializePlayers(string i_Player1Name, string i_Player2Name)
        {
            m_Players = new List<Player>();
            m_Players.Add(new Player('X', i_Player1Name));
            m_Players.Add(new Player('O', i_Player2Name));
            m_CurrentPlayer = m_Players[0];
        }

        private void board_UpdateBoard(int i_Row, int i_Column, char i_PlayerSymbol)
        {
            OnUpdateBoard(i_Row, i_Column, i_PlayerSymbol);
        }

        protected virtual void OnUpdateBoard(int i_Row, int i_Column, char i_PlayerSymbol)
        {
            if(UpdateBoard != null)
            {
                UpdateBoard.Invoke(i_Row, i_Column, i_PlayerSymbol);
            }
        }

        protected virtual void OnClearBoard()
        {
            if(ClearBoard != null)
            {
                ClearBoard.Invoke();
            }
        }

        protected virtual void OnUpdateScore(Player i_Player)
        {
            if(UpdateScore != null)
            {
                UpdateScore.Invoke(i_Player);
            }
        }

        public void HandleEndOfRound()
        {
            m_Board.ClearBoard();
            m_CurrentPlayer = m_Players[0];
            m_IsGameOver = false;
            OnClearBoard();
        }

        public void UpdateGame()
        {
            Player winner = null; // null for tie

            if (checkIfGameOver(m_CurrentPlayer.PlayerSymbol))
            {
                m_IsGameOver = true;
                setWinner(m_CurrentPlayer);
                winner = m_CurrentPlayer;
            }
            else if (m_Board.IsBoardFull())
            {
                m_IsGameOver = true;
            }

            if (m_IsGameOver)
            {
                OnGameOver(winner);
            }
            else
            {
                switchCurrentPlayer();
            }
        }

        private void setWinner(Player i_Winner)
        {
            i_Winner.Score++;
            OnUpdateScore(i_Winner);
        }

        private eGameError setPlayerChip(Player i_Player, int i_ColumnPlacement)
        {
            eGameError gameError = m_Board.SetGameChipAt(i_ColumnPlacement, new GameChip(i_Player.PlayerSymbol));

            if (gameError == eGameError.NoError)
            {
                UpdateGame();
            }

            return gameError;
        }

        private eGameError setComputerChip(Player i_ComputerPlayer)
        {
            int columnPlacement = getBestComputerMove(i_ComputerPlayer);
            eGameError gameError = m_Board.SetGameChipAt(columnPlacement, new GameChip(i_ComputerPlayer.PlayerSymbol));

            if (gameError == eGameError.NoError)
            {
                UpdateGame();
            }

            return gameError;
        }

        private int getBestComputerMove(Player i_ComputerPlayer)
        {
            char computerSymbol = i_ComputerPlayer.PlayerSymbol;
            char playerSymbol = m_Players[0].PlayerSymbol;
            int columnToPlay = -1;

            // Check if computer can win
            columnToPlay = checkIfPlayerCanWin(computerSymbol);

            if (columnToPlay == -1)
            {
                columnToPlay = checkIfPlayerCanWin(playerSymbol);
            }

            if (columnToPlay == -1)
            {
                columnToPlay = getRandomValidColumn();
            }

            return columnToPlay;
        }

        private int checkIfPlayerCanWin(char i_PlayerSymbol)
        {
            int columnToPlay = -1;

            for (int col = 0; col < m_Board.Width; col++)
            {
                if (m_Board.IsValidMove(col) && m_Board.WouldWin(col, i_PlayerSymbol))
                {
                    columnToPlay = col;
                    break;
                }
            }

            return columnToPlay;
        }

        private int getRandomValidColumn()
        {
            List<int> validColumns = m_Board.GetValidColumnsInBoard();

            return validColumns[r_Random.Next(validColumns.Count)];
        }


        private bool checkIfGameOver(char i_PlayerSymbol)
        {
            return m_Board.CheckBoardForFourInARow(i_PlayerSymbol);
        }

        public eGameError PlayTurn(int i_ColumnNumber)
        {
            eGameError gameError = eGameError.NoError;

            if (m_GameMode == eGameMode.PlayerVsPlayer)
            {
                gameError = setPlayerChip(m_CurrentPlayer, i_ColumnNumber);
            }
            else
            {
                gameError = setPlayerChip(m_CurrentPlayer, i_ColumnNumber);

                if(gameError == eGameError.NoError && !m_IsGameOver)
                {
                    gameError = setComputerChip(m_CurrentPlayer);
                }
            }

            return gameError;
        }

        protected virtual void OnGameOver(Player i_Winner)
        {
            if(GameOver != null)
            {
                GameOver.Invoke(i_Winner);
            }
        }

        private void switchCurrentPlayer()
        {
            if(m_CurrentPlayer == m_Players[0])
            {
                m_CurrentPlayer = m_Players[1];
            }
            else
            {
                m_CurrentPlayer = m_Players[0];
            }
        }
    }
}