namespace Milestone_MineSweeper_GUI
{
    partial class Form_RecordScore
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
            this.lbl_scoreMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_playerName = new System.Windows.Forms.TextBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.lbl_score = new System.Windows.Forms.Label();
            this.lbl_errorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_scoreMessage
            // 
            this.lbl_scoreMessage.AutoSize = true;
            this.lbl_scoreMessage.Location = new System.Drawing.Point(34, 37);
            this.lbl_scoreMessage.Name = "lbl_scoreMessage";
            this.lbl_scoreMessage.Size = new System.Drawing.Size(150, 13);
            this.lbl_scoreMessage.TabIndex = 0;
            this.lbl_scoreMessage.Text = "Congratulations! Your score is:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 70);
            this.label1.MaximumSize = new System.Drawing.Size(300, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter your name to have your score added to the leaderboard! You may use u" +
    "p to 5 characters.";
            // 
            // tb_playerName
            // 
            this.tb_playerName.Location = new System.Drawing.Point(37, 134);
            this.tb_playerName.Name = "tb_playerName";
            this.tb_playerName.Size = new System.Drawing.Size(100, 20);
            this.tb_playerName.TabIndex = 2;
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(37, 177);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 3;
            this.btn_submit.Text = "Submit!";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.Location = new System.Drawing.Point(191, 37);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(37, 13);
            this.lbl_score.TabIndex = 4;
            this.lbl_score.Text = "00000";
            // 
            // lbl_errorMessage
            // 
            this.lbl_errorMessage.AutoSize = true;
            this.lbl_errorMessage.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_errorMessage.Location = new System.Drawing.Point(37, 115);
            this.lbl_errorMessage.Name = "lbl_errorMessage";
            this.lbl_errorMessage.Size = new System.Drawing.Size(143, 13);
            this.lbl_errorMessage.TabIndex = 5;
            this.lbl_errorMessage.Text = "Please only use 5 characters";
            this.lbl_errorMessage.Visible = false;
            // 
            // Form_RecordScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 252);
            this.Controls.Add(this.lbl_errorMessage);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.tb_playerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_scoreMessage);
            this.Name = "Form_RecordScore";
            this.Text = "RecordScore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_scoreMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_playerName;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.Label lbl_errorMessage;
    }
}