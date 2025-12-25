using System;
using System.Collections.Generic;

namespace Ex02_1
{
    public class GameManager
    {
        private Board m_Board;
        private List<Player> m_Players;
        private eGameMode m_GameMode;
        private bool m_IsGameOver;
        private bool m_HasPlayerQuit;
        private readonly Random r_Random;
        private readonly UIManager r_UIManager;

        private GameManager()
        {
            r_Random = new Random();
            r_UIManager = new UIManager();
        }

        public static GameManager CreateGameManager()
        {
            GameManager gameManager = new GameManager();
            gameManager.initializePlayers();
            int boardHeight = gameManager.r_UIManager.GetBoardHeight();
            int boardWidth = gameManager.r_UIManager.GetBoardWidth();
            gameManager.m_Board = new Board(boardHeight, boardWidth);
            return gameManager;
        }

        private void initializePlayers()
        {
            m_Players = new List<Player>();
            m_Players.Add(new Player('X'));
            m_Players.Add(new Player('O'));
        }

        public void StartGame()
        {
            m_GameMode = r_UIManager.GetGameMode();
            r_UIManager.DisplayBoard(m_Board);

            while (!m_IsGameOver)
            {
                UpdateGame();

                if (m_IsGameOver)
                {
                    handleEndOfRound();
                }
            }
        }

        private void handleEndOfRound()
        {
            r_UIManager.DisplayScoreboard(m_Players);
            bool wantAnotherRound = r_UIManager.AskUserToPlayAnotherRound();

            if (wantAnotherRound)
            {
                m_Board.ClearBoard();
                m_HasPlayerQuit = false;
                m_IsGameOver = false;
                r_UIManager.DisplayBoard(m_Board);
            }
        }

        public void UpdateGame()
        {
            foreach (Player player in m_Players)
            {
                if (m_HasPlayerQuit) // flag to check if the previous player has quit
                {
                    setWinner(player);
                    r_UIManager.DisplayWinnerMessage(player);
                    break;
                }

                if (m_GameMode == eGameMode.PlayerVsComputer)
                {
                    if (player == m_Players[0])
                    {
                        setPlayerChip(player);
                    }
                    else
                    {
                        setComputerChip(player);
                    }
                }
                else if (m_GameMode == eGameMode.PlayerVsPlayer)
                {
                    setPlayerChip(player);
                }

                r_UIManager.DisplayBoard(m_Board);

                if (m_HasPlayerQuit)
                {
                    continue;
                }

                if (m_Board.IsBoardFull())
                {
                    m_IsGameOver = true;
                    r_UIManager.DisplayDrawMessage();
                    break;
                }
                else if (checkIfGameOver(player.PlayerSymbol))
                {
                    setWinner(player);
                    r_UIManager.DisplayWinnerMessage(player);
                    break;
                }
            }
        }

        private void setWinner(Player i_Winner)
        {
            i_Winner.Score++;
            m_IsGameOver = true;
        }

        private void setPlayerChip(Player i_Player)
        {
            bool isValidPlacement = false;

            while (!isValidPlacement && !m_IsGameOver)
            {
                int columnPlacement = r_UIManager.GetUserChipColumnPlacement(m_Board.Width, i_Player);

                if (columnPlacement == -1)
                {
                    m_IsGameOver = true;
                    m_HasPlayerQuit = true;
                    break;
                }

                eGameError gameError = m_Board.SetGameChipAt(columnPlacement, new GameChip(i_Player.PlayerSymbol));

                if (gameError != eGameError.NoError)
                {
                    r_UIManager.DisplayErrorMessage(gameError);
                }
                else
                {
                    isValidPlacement = true;
                }
            }
        }

        private void setComputerChip(Player i_ComputerPlayer)
        {
            bool isValidPlacement = false;

            while (!isValidPlacement && !m_IsGameOver)
            {
                int columnPlacement = getBestComputerMove(i_ComputerPlayer);
                eGameError gameError = m_Board.SetGameChipAt(columnPlacement, new GameChip(i_ComputerPlayer.PlayerSymbol));

                if (gameError == eGameError.NoError)
                {
                    isValidPlacement = true;
                }
            }
        }

        private int getBestComputerMove(Player i_ComputerPlayer)
        {
            char computerSymbol = i_ComputerPlayer.PlayerSymbol;
            char playerSymbol = m_Players[0].PlayerSymbol;
            int columnToPlay = -1;

            // Check if computer can win
            for (int col = 0; col < m_Board.Width; col++)
            {
                if (m_Board.IsValidMove(col) && m_Board.WouldWin(col, computerSymbol))
                {
                    columnToPlay = col;
                    break;
                }
            }

            if (columnToPlay == -1)
            {
                // Block player from winning
                for (int col = 0; col < m_Board.Width; col++)
                {
                    if (m_Board.IsValidMove(col) && m_Board.WouldWin(col, playerSymbol))
                    {
                        columnToPlay = col;
                        break;
                    }
                }
            }

            if (columnToPlay == -1)
            {
                // Random move
                List<int> validColumns = m_Board.GetValidColumnsInBoard();
                columnToPlay = validColumns[r_Random.Next(validColumns.Count)];
            }

            return columnToPlay;
        }

        private bool checkIfGameOver(char i_PlayerSymbol)
        {
            return m_Board.CheckBoardForFourInARow(i_PlayerSymbol);
        }
    }
}