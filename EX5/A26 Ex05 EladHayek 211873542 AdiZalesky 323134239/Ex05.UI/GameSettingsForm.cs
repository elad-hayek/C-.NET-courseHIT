using Ex05.Logic;
using System;
using System.Windows.Forms;

namespace Ex05.UI
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            GameManagerCreationParameters gameManagerParameters = new GameManagerCreationParameters();
            gameManagerParameters.BoardHeight = (int)m_NumericUpDownRows.Value;
            gameManagerParameters.BoardWidth = (int)m_NumericUpDownCols.Value;
            gameManagerParameters.Player1Name = m_TextBoxPlayer1.Text;

            if (m_CheckBoxPlayer2.Checked)
            {
                gameManagerParameters.GameMode = eGameMode.PlayerVsPlayer;
                gameManagerParameters.Player2Name = m_TextBoxPlayer2.Text;
            }
            else
            {
                gameManagerParameters.GameMode = eGameMode.PlayerVsComputer;
                gameManagerParameters.Player2Name = "Computer";
            }

            Hide();
            FourInARowForm fourInARowForm = new FourInARowForm(gameManagerParameters);
            fourInARowForm.ShowDialog();
            Close();
        }

        private void m_CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if(m_CheckBoxPlayer2.Checked)
            {
                m_TextBoxPlayer2.Enabled = true;
                m_TextBoxPlayer2.Text = string.Empty;
            }
            else
            {
                m_TextBoxPlayer2.Enabled = false;
                m_TextBoxPlayer2.Text = "[Computer]";
            }

            updateStartButtonState();
        }

        private void m_TextBoxPlayer1_TextChanged(object sender, EventArgs e)
        {
            updateStartButtonState();
        }

        private void m_TextBoxPlayer2_TextChanged(object sender, EventArgs e)
        {
            updateStartButtonState();
        }

        private void updateStartButtonState()
        {
            m_ButtonStart.Enabled = m_TextBoxPlayer1.Text.Length > 0 && m_TextBoxPlayer2.Text.Length > 0;
        }
    }
}
