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
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
        }

    }
}
