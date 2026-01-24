using Ex05.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.UI
{
    public partial class FourInARowForm : Form
    {
        private readonly GameManager r_GameManager;
        private List<Button> m_ColumnNumberButtons = new List<Button>();
        private Button[,] m_BoardButtons;
        private const int k_ButtonWidth = 40;
        private const int k_ColumnButtonHeight = 20;
        private const int k_CellButtonHeight = 30;
        private const int k_MarginSize = 10;
        private const int k_FormBorderWidth = 16;

        public FourInARowForm(GameManagerCreationParameters i_GameManagerParameters)
        {
            InitializeComponent();
            r_GameManager = new GameManager(i_GameManagerParameters);
            initializeDynamicComponents(i_GameManagerParameters);
        }

        private void initializeDynamicComponents(GameManagerCreationParameters i_GameManagerParameters)
        {
            int boardWidth = (i_GameManagerParameters.BoardWidth * k_ButtonWidth) + ((i_GameManagerParameters.BoardWidth - 1) * k_MarginSize);
            int boardHeight = (i_GameManagerParameters.BoardHeight * k_CellButtonHeight) + ((i_GameManagerParameters.BoardHeight - 1) * k_MarginSize);
            
            Width = boardWidth + (2 * k_MarginSize) + k_FormBorderWidth;
            Height = boardHeight + (2 * k_MarginSize) + (k_ColumnButtonHeight * i_GameManagerParameters.BoardHeight) + m_LabelPlayer1Name.Height;

            m_LabelPlayer1Name.Text = $"{i_GameManagerParameters.Player1Name}:";
            m_LabelPlayer2Name.Text = $"{i_GameManagerParameters.Player2Name}:";
            m_LabelPlayer1Score.Text = "0";
            m_LabelPlayer2Score.Text = "0";

            int boardTop = (k_MarginSize * 2) + k_ColumnButtonHeight;
            int labelsTop = boardTop + boardHeight + k_MarginSize;

            for (int col = 0; col < i_GameManagerParameters.BoardWidth; col++)
            {
                Button columnButton = new Button();
                columnButton.Text = $"{col + 1}";
                columnButton.Width = k_ButtonWidth;
                columnButton.Height = k_ColumnButtonHeight;
                columnButton.Top = k_MarginSize;
                columnButton.Left = k_MarginSize + (col * (k_ButtonWidth + k_MarginSize));
                columnButton.Click += columnButton_Click;
                m_ColumnNumberButtons.Add(columnButton);
                this.Controls.Add(columnButton);
            }

            m_BoardButtons = new Button[i_GameManagerParameters.BoardHeight, i_GameManagerParameters.BoardWidth];

            for (int row = 0; row < i_GameManagerParameters.BoardHeight; row++)
            {
                for (int col = 0; col < i_GameManagerParameters.BoardWidth; col++)
                {
                    Button cellButton = new Button();
                    cellButton.Width = k_ButtonWidth;
                    cellButton.Height = k_CellButtonHeight;
                    cellButton.Top = boardTop + (row * (k_CellButtonHeight + k_MarginSize));
                    cellButton.Left = k_MarginSize + (col * (k_ButtonWidth + k_MarginSize));
                    cellButton.Enabled = false;
                    m_BoardButtons[row, col] = cellButton;
                    this.Controls.Add(cellButton);
                }
            }

            m_LabelPlayer1Name.Top = labelsTop;
            m_LabelPlayer1Score.Top = labelsTop;
            m_LabelPlayer2Name.Top = labelsTop;
            m_LabelPlayer2Score.Top = labelsTop;
        }

        private void columnButton_Click(object sender, EventArgs e)
        {
            Button columnButton = sender as Button;
            int columnNumber = int.Parse(columnButton.Text) - 1;
        }
    }
}
