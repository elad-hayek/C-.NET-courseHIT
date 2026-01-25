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
        private const int k_ButtonWidth = 30;
        private const int k_ColumnButtonHeight = 20;
        private const int k_CellButtonHeight = 30;
        private const int k_MarginSize = 10;
        private const int k_FormBorderWidth = 16;
        private const int k_FormBorderHeight = 39;

        public FourInARowForm(GameManagerCreationParameters i_GameManagerParameters)
        {
            InitializeComponent();
            r_GameManager = new GameManager(i_GameManagerParameters);
            initializeDynamicComponents(i_GameManagerParameters);

            r_GameManager.UpdateBoard += gameManager_UpdateBoard;
            r_GameManager.ClearBoard += gameManager_ClearBoard;
            r_GameManager.UpdateScore += gameManager_UpdateScore;
            r_GameManager.GameOver += gameManager_GameOver;
            r_GameManager.ColumnFull += gameManager_ColumnFull;
        }

        private void gameManager_ColumnFull(int i_Column)
        {
            m_ColumnNumberButtons[i_Column].Enabled = false;
        }

        private void gameManager_GameOver(Player i_Player)
        {
            DialogResult result;

            if (i_Player == null)
            {
                string message = string.Format("Tie!!{0}Another Round?", Environment.NewLine);
                result = MessageBox.Show(message, "A Tie!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                string message = string.Format("{0} Won!!{1}Another Round?", i_Player.PlayerName, Environment.NewLine);
                result = MessageBox.Show(message, "A Win!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

            bool anotherRound = result == DialogResult.Yes;

            if (anotherRound)
            {
                foreach(Button columnButton in m_ColumnNumberButtons)
                {
                    columnButton.Enabled = true;
                }

                r_GameManager.HandleEndOfRound();
            }
            else
            {
                Close();
            }
        }

        private void gameManager_UpdateScore(Player i_Player)
        {
            if($"{i_Player.PlayerName}:" == m_LabelPlayer1Name.Text)
            {
                m_LabelPlayer1Score.Text = i_Player.Score.ToString();
            }
            else
            {
                m_LabelPlayer2Score.Text = i_Player.Score.ToString();
            }
        }

        private void gameManager_ClearBoard()
        {
            foreach(Button cellButton in m_BoardButtons)
            {
                cellButton.Text = string.Empty;
            }
        }

        private void initializeDynamicComponents(GameManagerCreationParameters i_GameManagerParameters)
        {
            //Controls.Remove(m_LabelPlayer1Name);
            //Controls.Remove(m_LabelPlayer1Score);
            //Controls.Remove(m_LabelPlayer2Name);
            //Controls.Remove(m_LabelPlayer2Score);

            int boardWidth = (i_GameManagerParameters.BoardWidth * k_ButtonWidth) + ((i_GameManagerParameters.BoardWidth - 1) * k_MarginSize);
            int boardHeight = (i_GameManagerParameters.BoardHeight * k_CellButtonHeight) + ((i_GameManagerParameters.BoardHeight - 1) * k_MarginSize);
            
            Width = boardWidth + (2 * k_MarginSize) + k_FormBorderWidth;
            Height = boardHeight + (3 * k_MarginSize) + k_CellButtonHeight + k_FormBorderHeight + m_LabelPlayer1Name.Height;

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

            r_GameManager.PlayTurn(columnNumber);
        }

        private void gameManager_UpdateBoard(int i_Row, int i_Col, char i_PlayerSymbol)
        {
            Button cellButton = m_BoardButtons[i_Row, i_Col];
            cellButton.Text = i_PlayerSymbol.ToString();
        }
    }
}
