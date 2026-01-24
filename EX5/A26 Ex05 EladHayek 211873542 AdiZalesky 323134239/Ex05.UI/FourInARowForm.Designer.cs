namespace Ex05.UI
{
    partial class FourInARowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_LabelPlayer1Name = new System.Windows.Forms.Label();
            this.m_LabelPlayer1Score = new System.Windows.Forms.Label();
            this.m_LabelPlayer2Name = new System.Windows.Forms.Label();
            this.m_LabelPlayer2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_LabelPlayer1Name
            // 
            this.m_LabelPlayer1Name.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_LabelPlayer1Name.AutoSize = true;
            this.m_LabelPlayer1Name.Location = new System.Drawing.Point(92, 299);
            this.m_LabelPlayer1Name.Name = "m_LabelPlayer1Name";
            this.m_LabelPlayer1Name.Size = new System.Drawing.Size(35, 13);
            this.m_LabelPlayer1Name.TabIndex = 0;
            this.m_LabelPlayer1Name.Text = "label1";
            // 
            // m_LabelPlayer1Score
            // 
            this.m_LabelPlayer1Score.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_LabelPlayer1Score.AutoSize = true;
            this.m_LabelPlayer1Score.Location = new System.Drawing.Point(133, 299);
            this.m_LabelPlayer1Score.Name = "m_LabelPlayer1Score";
            this.m_LabelPlayer1Score.Size = new System.Drawing.Size(35, 13);
            this.m_LabelPlayer1Score.TabIndex = 1;
            this.m_LabelPlayer1Score.Text = "label2";
            // 
            // m_LabelPlayer2Name
            // 
            this.m_LabelPlayer2Name.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_LabelPlayer2Name.AutoSize = true;
            this.m_LabelPlayer2Name.Location = new System.Drawing.Point(220, 299);
            this.m_LabelPlayer2Name.Name = "m_LabelPlayer2Name";
            this.m_LabelPlayer2Name.Size = new System.Drawing.Size(35, 13);
            this.m_LabelPlayer2Name.TabIndex = 2;
            this.m_LabelPlayer2Name.Text = "label3";
            // 
            // m_LabelPlayer2Score
            // 
            this.m_LabelPlayer2Score.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_LabelPlayer2Score.AutoSize = true;
            this.m_LabelPlayer2Score.Location = new System.Drawing.Point(292, 299);
            this.m_LabelPlayer2Score.Name = "m_LabelPlayer2Score";
            this.m_LabelPlayer2Score.Size = new System.Drawing.Size(35, 13);
            this.m_LabelPlayer2Score.TabIndex = 3;
            this.m_LabelPlayer2Score.Text = "label4";
            // 
            // FourInARowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 347);
            this.Controls.Add(this.m_LabelPlayer2Score);
            this.Controls.Add(this.m_LabelPlayer2Name);
            this.Controls.Add(this.m_LabelPlayer1Score);
            this.Controls.Add(this.m_LabelPlayer1Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FourInARowForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "4 in a Row !!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_LabelPlayer1Name;
        private System.Windows.Forms.Label m_LabelPlayer1Score;
        private System.Windows.Forms.Label m_LabelPlayer2Name;
        private System.Windows.Forms.Label m_LabelPlayer2Score;
    }
}