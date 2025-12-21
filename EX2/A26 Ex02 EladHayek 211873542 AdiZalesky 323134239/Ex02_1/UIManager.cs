using System;

namespace Ex02_1
{
    public static class UIManager
    {
        public static void DisplayBoard(Board i_Board)
        {
            // TODO: Implement the method to display the board

            //for (int i = 0; i < i_Board.Height; i++)
            //{
            //    for (int j = 0; j < i_Board.Width; j++)
            //    {
            //        GameChip? gameChip = i_Board.GetGameChipAt(j, i);
            //        char symbolToDisplay = gameChip.HasValue ? gameChip.Value.PlayerId : '.';
            //        System.Console.Write(symbolToDisplay + " ");
            //    }
            //    System.Console.WriteLine();
            //}
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
            switch(i_GameError)
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
                Console.Write("Please enter the column to place your chip: ");
                string userInput = Console.ReadLine();

                if(userInput == "Q")
                {
                    isValidInput = true;
                }
                else if (int.TryParse(userInput, out column) && column >= 0 && column < i_NumberOfColumns)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a number between 0 and {i_NumberOfColumns} or Q to forfit.");
                }
            }

            return column;
        }
    }
}
