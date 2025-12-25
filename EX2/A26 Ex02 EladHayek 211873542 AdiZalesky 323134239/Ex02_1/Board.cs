namespace Ex02_1
{
    public class Board
    {
        private readonly GameChip?[,] r_BoardMatrix;
        private const int k_MinBoardDimension = 4;
        private const int k_MaxBoardDimension = 8;

        public int Width
        {
            get
            {
                return r_BoardMatrix.GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return r_BoardMatrix.GetLength(0);
            }
        }

        public Board(int i_Height, int i_Width)
        {
            r_BoardMatrix = new GameChip?[i_Height, i_Width];
        }

        public GameChip? GetGameChipAt(int i_X, int i_Y)
        {
            return r_BoardMatrix[i_X, i_Y];
        }

        public eGameError SetGameChipAt(int i_Column, GameChip i_GameChip)
        {
            eGameError error = ValidateColumn(i_Column);

            if (error == eGameError.NoError)
            {
                int nextEmptyRow = GetFirstEmptyRowInColumn(i_Column);
                r_BoardMatrix[nextEmptyRow, i_Column] = i_GameChip;
            }

            return error;
        }

        private int GetFirstEmptyRowInColumn(int i_Column)
        {
            int row = Height - 1;

            while (row >= 0 && r_BoardMatrix[row, i_Column] != null)
            {
                row--;
            }

            return row;
        }

        public static eGameError ValidateBoardDimension(int i_DimentionValue)
        {
            bool isValid = i_DimentionValue >= k_MinBoardDimension && i_DimentionValue <= k_MaxBoardDimension;

            eGameError gameError = eGameError.NoError;

            if (!isValid)
            {
                gameError = eGameError.InvalidBoardDimensions;
            }

            return gameError;
        }

        private bool ValidateColumnInRange(int i_Column)
        {
            return i_Column >= 0 && i_Column < Width;
        }

        private eGameError ValidateColumn(int i_Column)
        {
            bool isVald = ValidateColumnInRange(i_Column);
            eGameError gameError = eGameError.NoError;

            if (!isVald)
            {
                gameError = eGameError.InvalidColumn;
            }
            else if (r_BoardMatrix[0, i_Column] != null)
            {
                gameError = eGameError.ColumnIsFull;
            }

            return gameError;
        }

        public bool IsBoardFull()
        {
            bool isFull = true;

            for (int col = 0; col < Width; col++)
            {
                if (r_BoardMatrix[0, col] == null)
                {
                    isFull = false;
                    break;
                }
            }

            return isFull;
        }

        public bool CheckBoardForFourInARow(char i_PlayerSymbol)
        {
            bool isFourInARow = false;

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    if (CheckDirection(row, col, 0, 1, i_PlayerSymbol) || // Horizontal
                        CheckDirection(row, col, 1, 0, i_PlayerSymbol) || // Vertical
                        CheckDirection(row, col, 1, 1, i_PlayerSymbol) || // Diagonal down-right
                        CheckDirection(row, col, 1, -1, i_PlayerSymbol))  // Diagonal down-left
                    {
                        isFourInARow = true;
                        break;
                    }
                }

                if (isFourInARow)
                {
                    break;
                }
            }

            return isFourInARow;
        }

        private bool CheckDirection(int i_StartRow, int i_StartCol, int i_DeltaRow, int i_DeltaCol, char i_PlayerSymbol)
        {
            int count = 0;

            for (int i = 0; i < 4; i++)
            {
                int row = i_StartRow + i * i_DeltaRow;
                int col = i_StartCol + i * i_DeltaCol;

                if (row < 0 || row >= Height || col < 0 || col >= Width)
                {
                    return false;
                }

                GameChip? gameChip = r_BoardMatrix[row, col];

                if (gameChip != null && gameChip.Value.PlayerSymbol == i_PlayerSymbol)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count == 4;
        }

        public void ClearBoard()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    r_BoardMatrix[row, col] = null;
                }
            }
        }

        public bool IsValidMove(int i_Column)
        {
            return ValidateColumn(i_Column) == eGameError.NoError;
        }

        public bool WouldWin(int i_Column, char i_PlayerSymbol)
        {
            int targetRow = GetFirstEmptyRowInColumn(i_Column);
            GameChip tempChip = new GameChip(i_PlayerSymbol);
            r_BoardMatrix[targetRow, i_Column] = tempChip;
            bool wouldWin = CheckBoardForFourInARow(i_PlayerSymbol);
            r_BoardMatrix[targetRow, i_Column] = null;
            return wouldWin;
        }
    }
}
