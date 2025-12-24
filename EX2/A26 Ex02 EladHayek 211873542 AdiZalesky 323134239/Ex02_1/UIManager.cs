using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02_1
{
    public class UIManager
    {
        private readonly StringBuilder r_StringBuilder = new StringBuilder();

        public void DisplayBoard(Board i_Board)
        {
            r_StringBuilder.Clear();
            Console.Clear();
            int columnHeader = 'A';

            for (int i = 0; i < i_Board.Width; i++)
            {
                r_StringBuilder.AppendFormat("  {0} ", (char)(columnHeader + i));
            }

            r_StringBuilder.Append(Environment.NewLine);

            for (int row = 0; row < i_Board.Height; row++)
            {
                for (int col = 0; col < i_Board.Width; col++)
                {
                    r_StringBuilder.Append("| ");
                    GameChip? gameChip = i_Board.GetGameChipAt(row, col);
                    r_StringBuilder.Append(gameChip?.PlayerSymbol.ToString() ?? " ");
                    r_StringBuilder.Append(" ");
                }
                r_StringBuilder.Append("|");
                r_StringBuilder.AppendLine();
                r_StringBuilder.AppendLine(new string('=', i_Board.Width * 3 + i_Board.Width + 1));
            }

            Console.WriteLine(r_StringBuilder.ToString());
        }

        private static int GetBoardDimention(string i_DimentionName)
        {
            int dimension = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write($"Please enter the board {i_DimentionName} (4-8): ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out dimension))
                {
                    eGameError error = Board.ValidateBoardDimension(dimension);

                    if (error == eGameError.NoError)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid board {i_DimentionName}. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            return dimension;
        }

        public static int GetBoardWidth()
        {
            return GetBoardDimention("width");
        }

        public static int GetBoardHeight()
        {
            return GetBoardDimention("height");
        }

        public static eGameMode GetGameMode()
        {
            int gameModeInput = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write("Please choose game mode: 1 for Player vs Player, 2 for Player vs Computer: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out gameModeInput) &&
                    (gameModeInput == (int)eGameMode.PlayerVsPlayer || gameModeInput == (int)eGameMode.PlayerVsComputer))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2.");
                }
            }

            eGameMode gameMode = (eGameMode)gameModeInput;
            return gameMode;
        }

        public static void DisplayErrorMessage(eGameError i_GameError)
        {
            switch (i_GameError)
            {
                case eGameError.InvalidBoardDimensions:
                    Console.WriteLine("Error: Invalid board dimensions. Please enter values between 4 and 8.");
                    break;
                case eGameError.InvalidColumn:
                    Console.WriteLine("Error: Invalid column. Please try again.");
                    break;
                case eGameError.ColumnIsFull:
                    Console.WriteLine("Error: column is full. Please choose another column.");
                    break;
                default:
                    Console.WriteLine("An unknown error occurred.");
                    break;
            }
        }

        public static int GetUserChipColumnPlacment(int i_NumberOfColumns)
        {
            int column = -1;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write("Please enter the column to place your chip (Ex: A, B ...): ");
                string userInput = Console.ReadLine();

                if (userInput == "Q")
                {
                    isValidInput = true;
                }
                else if (ValidateColumnInput(userInput, i_NumberOfColumns, out column))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine(
                        $"Invalid input. Please enter a number between A and {(char)('A' + i_NumberOfColumns - 1)} or Q to forfit.");
                }
            }

            return column;
        }

        private static bool ValidateColumnInput(string i_UserInput, int i_NumberOfColumns, out int o_Column)
        {
            o_Column = -1;
            bool isValid = false;

            if (!string.IsNullOrEmpty(i_UserInput) && i_UserInput.Length == 1)
            {
                char inputChar = char.ToUpper(i_UserInput[0]);
                int columnIndex = inputChar - 'A';

                if (columnIndex >= 0 && columnIndex < i_NumberOfColumns)
                {
                    o_Column = columnIndex;
                    isValid = true;
                }
            }

            return isValid;
        }

        public static void DisplayScoreboard(List<Player> i_Players)
        {
            Console.WriteLine("Scoreboard:");

            if (i_Players == null || i_Players.Count == 0)
            {
                Console.WriteLine("No players to display.");
            }
            else
            {
                foreach (Player player in i_Players)
                {
                    Console.WriteLine($"Player '{player.PlayerSymbol}': {player.Score} points");
                }
            }
        }

        public static void DisplayWinnerMessage(Player i_Winner)
        {
            if (i_Winner != null)
            {
                Console.WriteLine($"Player '{i_Winner.PlayerSymbol}' wins this round!");
            }
            else
            {
                Console.WriteLine("No winner found");
            }
        }

        public static void DisplayDrawMessage()
        {
            Console.WriteLine("The game ended in a draw!");
        }

        public static bool AskUserToPlayAnotherRound()
        {
            bool isValidInput = false;
            string userInput = Console.ReadLine();

            while (!isValidInput)
            {
                Console.Write("Do you want to play another round? (Y/N): ");

                if (!string.IsNullOrEmpty(userInput) &&
                   (userInput.Equals("Y", StringComparison.OrdinalIgnoreCase) ||
                    userInput.Equals("N", StringComparison.OrdinalIgnoreCase)))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                }
            }

            return userInput.Equals("Y", StringComparison.OrdinalIgnoreCase);
        }
    }
}
