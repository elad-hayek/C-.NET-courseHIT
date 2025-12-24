
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
            }

            // TODO: add logic for displaying final results and update score
        }

        public void UpdateGame()
        {
            foreach (Player player in m_Players)
            {
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
                CheckIfGameOver();

                if (m_IsGameOver)
                {
                    break;
                }
            }
        }

        private void SetPlayerChip(Player i_Player)
        {
            bool isValidPlacement = false;

            while (!isValidPlacement && !m_IsGameOver)
            {
                int columnPlacement = UIManager.GetUserChipColumnPlacment(r_Board.Width);

                if (columnPlacement == -1)
                {
                    // TODO: handle user quit action, add score to the opponent
                    m_IsGameOver = true;
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
                // TODO: Improve computer logic
                int columnPlacement = r_Random.Next(0, r_Board.Width - 1);

                eGameError gameError = r_Board.SetGameChipAt(columnPlacement, new GameChip(i_ComputerPlayer.PlayerSymbol));
                if (gameError == eGameError.NoError)
                {
                    isValidPlacement = true;
                }
            }
        }

        private bool CheckIfGameOver()
        {
            // TODO: Implement game over logic
            return false;
        }

    }
}
