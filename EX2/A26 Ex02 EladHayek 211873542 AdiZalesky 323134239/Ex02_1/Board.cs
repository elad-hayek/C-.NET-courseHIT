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
                return r_BoardMatrix.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return r_BoardMatrix.GetLength(1);
            }
        }

        public Board(int i_Width, int i_Height)
        {
            r_BoardMatrix = new GameChip?[i_Width, i_Height];
        }

        public GameChip? GetGameChipAt(int i_X, int i_Y)
        {
            return r_BoardMatrix[i_X, i_Y];
        }

        public eGameError SetGameChipAt(int i_Column, GameChip i_GameChip)
        {
            eGameError error = ValidateColumn(i_Column);

            if(error == eGameError.NoError)
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
            return i_Column >= 0 && i_Column < Width ;
        }

        private eGameError ValidateColumn(int i_Column)
        {
            bool isVald = ValidateColumnInRange(i_Column);
            eGameError gameError = eGameError.NoError;

            if(!isVald)
            {
                gameError = eGameError.InvalidColumn;
            }
            else if (r_BoardMatrix[0, i_Column] != null)
            {
                gameError = eGameError.ColumnIsFull;
            }

            return gameError;
        }
    }
}
