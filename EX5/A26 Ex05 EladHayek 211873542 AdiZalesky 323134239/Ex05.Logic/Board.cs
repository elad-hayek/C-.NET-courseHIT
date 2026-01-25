using System;
using System.Collections.Generic;

namespace Ex05.Logic
{
    public class Board
    {
        private readonly GameChip?[,] r_BoardMatrix;
        private const int k_MinBoardDimension = 4;
        private const int k_MaxBoardDimension = 10;
        private readonly int r_Height;
        private readonly int r_Width;

        public event Action<int, int, char> UpdateBoard;
        public event Action<int> ColumnFull;

        public int Width
        {
            get
            {
                return r_Width;
            }
        }

        public int Height
        {
            get
            {
                return r_Height;
            }
        }

        public Board(int i_Height, int i_Width)
        {
            r_BoardMatrix = new GameChip?[i_Height, i_Width];
            r_Height = i_Height;
            r_Width = i_Width;
        }

        public GameChip? GetGameChipAt(int i_Row, int i_Column)
        {
            return r_BoardMatrix[i_Row, i_Column];
        }

        public eGameError SetGameChipAt(int i_Column, GameChip i_GameChip)
        {
            eGameError error = validateColumn(i_Column);

            if (error == eGameError.NoError)
            {
                int nextEmptyRow = getFirstEmptyRowInColumn(i_Column);
                r_BoardMatrix[nextEmptyRow, i_Column] = i_GameChip;
                OnUpdateBoard(nextEmptyRow, i_Column, i_GameChip.PlayerSymbol);

                if (nextEmptyRow == 0)
                {
                    OnColumnFull(i_Column);
                }
            }

            return error;
        }

        protected virtual void OnUpdateBoard(int i_Row, int i_Column, char i_PlayerSymbol)
        {
            if(UpdateBoard != null)
            {
                UpdateBoard.Invoke(i_Row, i_Column, i_PlayerSymbol);
            }
        }

        protected virtual void OnColumnFull(int i_Column)
        {
            if(ColumnFull != null)
            {
                ColumnFull.Invoke(i_Column);
            }
        }

        private int getFirstEmptyRowInColumn(int i_Column)
        {
            int row = Height - 1;

            while (row >= 0 && r_BoardMatrix[row, i_Column] != null)
            {
                row--;
            }

            return row;
        }

        public static eGameError ValidateBoardDimension(int i_DimensionValue)
        {
            bool isValid = i_DimensionValue >= k_MinBoardDimension && i_DimensionValue <= k_MaxBoardDimension;

            eGameError gameError = eGameError.NoError;

            if (!isValid)
            {
                gameError = eGameError.InvalidBoardDimensions;
            }

            return gameError;
        }

        private bool validateColumnInRange(int i_Column)
        {
            return i_Column >= 0 && i_Column < Width;
        }

        private eGameError validateColumn(int i_Column)
        {
            bool isValid = validateColumnInRange(i_Column);
            eGameError gameError = eGameError.NoError;

            if (!isValid)
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
                    if (checkDirection(row, col, 0, 1, i_PlayerSymbol) || // Horizontal
                        checkDirection(row, col, 1, 0, i_PlayerSymbol) || // Vertical
                        checkDirection(row, col, 1, 1, i_PlayerSymbol) || // Diagonal down-right
                        checkDirection(row, col, 1, -1, i_PlayerSymbol))  // Diagonal down-left
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

        private bool checkDirection(int i_StartRow, int i_StartCol, int i_DeltaRow, int i_DeltaCol, char i_PlayerSymbol)
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
            return validateColumn(i_Column) == eGameError.NoError;
        }

        public bool WouldWin(int i_Column, char i_PlayerSymbol)
        {
            int targetRow = getFirstEmptyRowInColumn(i_Column);
            bool wouldWin = false;

            if (targetRow != -1)
            {
                GameChip tempChip = new GameChip(i_PlayerSymbol);
                r_BoardMatrix[targetRow, i_Column] = tempChip;
                wouldWin = CheckBoardForFourInARow(i_PlayerSymbol);
                r_BoardMatrix[targetRow, i_Column] = null;
            }

            return wouldWin;
        }

        public List<int> GetValidColumnsInBoard()
        {
            List<int> validColumns = new List<int>();

            for (int col = 0; col < Width; col++)
            {
                if (r_BoardMatrix[0, col] == null)
                {
                    validColumns.Add(col);
                }
            }

            return validColumns;
        }
    }
}