
using System;
using System.Collections.Generic;

namespace Ex02_1
{
    public class GameManager
    {
        private Board r_Board;
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
            gameManager.InitializePlayers();
            int boardHeight = UIManager.GetBoardHeight();
            int boardWidth = UIManager.GetBoardWidth();
            gameManager.r_Board = new Board(boardHeight, boardWidth);
            return gameManager;
        }

        private void InitializePlayers()
        {
            m_Players = new List<Player>();
            m_Players.Add(new Player('X'));
            m_Players.Add(new Player('O'));
        }

        public void StartGame()
        {
            m_GameMode = UIManager.GetGameMode();
            r_UIManager.DisplayBoard(r_Board);

            while (!m_IsGameOver)
            {
                UpdateGame();

                if (m_IsGameOver)
                {
                    HandleEndOfRound();
                }
            }
        }

        private void HandleEndOfRound()
        {
            UIManager.DisplayScoreboard(m_Players);
            bool wantAnotherRound = UIManager.AskUserToPlayAnotherRound();

            if (wantAnotherRound)
            {
                r_Board.ClearBoard();
                m_HasPlayerQuit = false;
                m_IsGameOver = false;
                r_UIManager.DisplayBoard(r_Board);
            }
        }

        public void UpdateGame()
        {
            foreach (Player player in m_Players)
            {
                if (m_HasPlayerQuit) // flag to check if the previous player has quit
                {
                    SetWinner(player);
                    UIManager.DisplayWinnerMessage(player);
                    break;
                }

                if (m_GameMode == eGameMode.PlayerVsComputer)
                {
                    if (player == m_Players[0])
                    {
                        SetPlayerChip(player);
                    }
                    else
                    {
                        SetComputerChip(player);
                    }
                }
                else if (m_GameMode == eGameMode.PlayerVsPlayer)
                {
                    SetPlayerChip(player);
                }

                r_UIManager.DisplayBoard(r_Board);

                if (m_HasPlayerQuit)
                {
                    continue;
                }

                if (r_Board.IsBoardFull())
                {
                    m_IsGameOver = true;
                    UIManager.DisplayDrawMessage();
                    break;
                }
                else if (CheckIfGameOver(player.PlayerSymbol))
                {
                    SetWinner(player);
                    UIManager.DisplayWinnerMessage(player);
                    break;
                }
            }
        }

        private void SetWinner(Player i_Winner)
        {
            i_Winner.Score++;
            m_IsGameOver = true;
        }

        private void SetPlayerChip(Player i_Player)
        {
            bool isValidPlacement = false;

            while (!isValidPlacement && !m_IsGameOver)
            {
                int columnPlacement = UIManager.GetUserChipColumnPlacment(r_Board.Width, i_Player);

                if (columnPlacement == -1)
                {
                    m_IsGameOver = true;
                    m_HasPlayerQuit = true;
                    break;
                }

                eGameError gameError = r_Board.SetGameChipAt(columnPlacement, new GameChip(i_Player.PlayerSymbol));

                if (gameError != eGameError.NoError)
                {
                    UIManager.DisplayErrorMessage(gameError);
                }
                else
                {
                    isValidPlacement = true;
                }
            }
        }

        private void SetComputerChip(Player i_ComputerPlayer)
        {
            bool isValidPlacement = false;

            while (!isValidPlacement && !m_IsGameOver)
            {
                int columnPlacement = GetBestComputerMove(i_ComputerPlayer);

                eGameError gameError = r_Board.SetGameChipAt(columnPlacement, new GameChip(i_ComputerPlayer.PlayerSymbol));
                if (gameError == eGameError.NoError)
                {
                    isValidPlacement = true;
                }
            }
        }

        private int GetBestComputerMove(Player i_ComputerPlayer)
        {
            char computerSymbol = i_ComputerPlayer.PlayerSymbol;
            char playerSymbol = m_Players[0].PlayerSymbol;
            int columnToPlay = -1;

            // Check if computer can win
            for (int col = 0; col < r_Board.Width; col++)
            {
                if (r_Board.IsValidMove(col) && r_Board.WouldWin(col, computerSymbol))
                {
                    columnToPlay = col;
                    break;
                }
            }

            if(columnToPlay == -1)
            {
                // Block player from winning
                for (int col = 0; col < r_Board.Width; col++)
                {
                    if (r_Board.IsValidMove(col) && r_Board.WouldWin(col, playerSymbol))
                    {
                        columnToPlay = col;
                        break;
                    }
                }
            }

            if(columnToPlay == -1)
            {
                // Random move
                columnToPlay = r_Random.Next(0, r_Board.Width - 1);
            }

            return columnToPlay;
        }

        private bool CheckIfGameOver(char i_PlayerSymbol)
        {
            return r_Board.CheckBoardForFourInARow(i_PlayerSymbol);
        }

    }
}
