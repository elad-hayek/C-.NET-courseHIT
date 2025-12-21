
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
        private readonly Random m_Random;

        private GameManager()
        {
            m_Random = new Random();
        }

        public static GameManager CreateGameManager()
        {
            GameManager gameManager = new GameManager();
            gameManager.InitializePlayers();
            int boardWidth = UIManager.GetBoardWidth();
            int boardHeight = UIManager.GetBoardHeight();

            gameManager.r_Board = new Board(boardWidth, boardHeight);
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

            while (!m_IsGameOver)
            {
                UpdateGame();
            }
        }

        public void UpdateGame()
        {
            foreach (Player player in m_Players)
            {
                if (m_GameMode == eGameMode.PlayerVsComputer)
                {
                    if(player == m_Players[0])
                    {
                        SetPlayerChip(player);
                    }
                    else
                    {
                        SetComputerChip(player);
                    }
                }
                else if(m_GameMode == eGameMode.PlayerVsPlayer)
                {
                    SetPlayerChip(player);
                }

                UIManager.DisplayBoard(r_Board);
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

            while(!isValidPlacement && !m_IsGameOver)
            {
                int columnPlacement = UIManager.GetUserChipColumnPlacment(r_Board.Width);

                if (columnPlacement == -1)
                {
                    m_IsGameOver = true;
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
                int columnPlacement = m_Random.Next();

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
