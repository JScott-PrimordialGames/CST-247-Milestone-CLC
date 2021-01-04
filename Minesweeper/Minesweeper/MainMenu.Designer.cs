namespace Minesweeper
{
    partial class MainMenu
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
            this.RB_Easy = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.RB_Moderate = new System.Windows.Forms.RadioButton();
            this.RB_Hard = new System.Windows.Forms.RadioButton();
            this.RB_Explotion = new System.Windows.Forms.RadioButton();
            this.BTN_Play = new System.Windows.Forms.Button();
            this.BTN_MMHighScore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RB_Easy
            // 
            this.RB_Easy.AutoSize = true;
            this.RB_Easy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Easy.Location = new System.Drawing.Point(72, 32);
            this.RB_Easy.Name = "RB_Easy";
            this.RB_Easy.Size = new System.Drawing.Size(59, 22);
            this.RB_Easy.TabIndex = 0;
            this.RB_Easy.TabStop = true;
            this.RB_Easy.Text = "Easy";
            this.RB_Easy.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Dificulty Level";
            // 
            // RB_Moderate
            // 
            this.RB_Moderate.AutoSize = true;
            this.RB_Moderate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Moderate.Location = new System.Drawing.Point(72, 60);
            this.RB_Moderate.Name = "RB_Moderate";
            this.RB_Moderate.Size = new System.Drawing.Size(89, 22);
            this.RB_Moderate.TabIndex = 2;
            this.RB_Moderate.TabStop = true;
            this.RB_Moderate.Text = "Moderate";
            this.RB_Moderate.UseVisualStyleBackColor = true;
            // 
            // RB_Hard
            // 
            this.RB_Hard.AutoSize = true;
            this.RB_Hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Hard.Location = new System.Drawing.Point(72, 88);
            this.RB_Hard.Name = "RB_Hard";
            this.RB_Hard.Size = new System.Drawing.Size(58, 22);
            this.RB_Hard.TabIndex = 3;
            this.RB_Hard.TabStop = true;
            this.RB_Hard.Text = "Hard";
            this.RB_Hard.UseVisualStyleBackColor = true;
            // 
            // RB_Explotion
            // 
            this.RB_Explotion.AutoSize = true;
            this.RB_Explotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Explotion.Location = new System.Drawing.Point(72, 116);
            this.RB_Explotion.Name = "RB_Explotion";
            this.RB_Explotion.Size = new System.Drawing.Size(104, 22);
            this.RB_Explotion.TabIndex = 4;
            this.RB_Explotion.TabStop = true;
            this.RB_Explotion.Text = "Explotions!!!";
            this.RB_Explotion.UseVisualStyleBackColor = true;
            // 
            // BTN_Play
            // 
            this.BTN_Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Play.Location = new System.Drawing.Point(82, 144);
            this.BTN_Play.Name = "BTN_Play";
            this.BTN_Play.Size = new System.Drawing.Size(75, 38);
            this.BTN_Play.TabIndex = 5;
            this.BTN_Play.Text = "Play";
            this.BTN_Play.UseVisualStyleBackColor = true;
            this.BTN_Play.Click += new System.EventHandler(this.BTN_Play_Click);
            // 
            // BTN_MMHighScore
            // 
            this.BTN_MMHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_MMHighScore.Location = new System.Drawing.Point(56, 188);
            this.BTN_MMHighScore.Name = "BTN_MMHighScore";
            this.BTN_MMHighScore.Size = new System.Drawing.Size(132, 26);
            this.BTN_MMHighScore.TabIndex = 6;
            this.BTN_MMHighScore.Text = "View High Scores";
            this.BTN_MMHighScore.UseVisualStyleBackColor = true;
            this.BTN_MMHighScore.Click += new System.EventHandler(this.BTN_MMHighScore_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 223);
            this.Controls.Add(this.BTN_MMHighScore);
            this.Controls.Add(this.BTN_Play);
            this.Controls.Add(this.RB_Explotion);
            this.Controls.Add(this.RB_Hard);
            this.Controls.Add(this.RB_Moderate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RB_Easy);
            this.Name = "MainMenu";
            this.Text = "Set Dificulty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RB_Easy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RB_Moderate;
        private System.Windows.Forms.RadioButton RB_Hard;
        private System.Windows.Forms.RadioButton RB_Explotion;
        private System.Windows.Forms.Button BTN_Play;
        private System.Windows.Forms.Button BTN_MMHighScore;
    }
}

