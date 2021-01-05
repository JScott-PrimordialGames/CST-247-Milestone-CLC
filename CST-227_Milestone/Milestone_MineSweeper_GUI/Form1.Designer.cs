namespace Milestone_MineSweeper_GUI
{
    partial class Form1
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
            this.groupBox_DifficultySelection = new System.Windows.Forms.GroupBox();
            this.radioButton_difficult = new System.Windows.Forms.RadioButton();
            this.radioButton_moderate = new System.Windows.Forms.RadioButton();
            this.radioButton_easy = new System.Windows.Forms.RadioButton();
            this.btn_startGame = new System.Windows.Forms.Button();
            this.groupBox_DifficultySelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_DifficultySelection
            // 
            this.groupBox_DifficultySelection.Controls.Add(this.radioButton_difficult);
            this.groupBox_DifficultySelection.Controls.Add(this.radioButton_moderate);
            this.groupBox_DifficultySelection.Controls.Add(this.radioButton_easy);
            this.groupBox_DifficultySelection.Location = new System.Drawing.Point(13, 13);
            this.groupBox_DifficultySelection.Name = "groupBox_DifficultySelection";
            this.groupBox_DifficultySelection.Size = new System.Drawing.Size(269, 133);
            this.groupBox_DifficultySelection.TabIndex = 0;
            this.groupBox_DifficultySelection.TabStop = false;
            this.groupBox_DifficultySelection.Text = "Select Difficulty";
            // 
            // radioButton_difficult
            // 
            this.radioButton_difficult.AutoSize = true;
            this.radioButton_difficult.Location = new System.Drawing.Point(37, 108);
            this.radioButton_difficult.Name = "radioButton_difficult";
            this.radioButton_difficult.Size = new System.Drawing.Size(60, 17);
            this.radioButton_difficult.TabIndex = 0;
            this.radioButton_difficult.TabStop = true;
            this.radioButton_difficult.Text = "Difficult";
            this.radioButton_difficult.UseVisualStyleBackColor = true;
            // 
            // radioButton_moderate
            // 
            this.radioButton_moderate.AutoSize = true;
            this.radioButton_moderate.Location = new System.Drawing.Point(37, 75);
            this.radioButton_moderate.Name = "radioButton_moderate";
            this.radioButton_moderate.Size = new System.Drawing.Size(70, 17);
            this.radioButton_moderate.TabIndex = 0;
            this.radioButton_moderate.TabStop = true;
            this.radioButton_moderate.Text = "Moderate";
            this.radioButton_moderate.UseVisualStyleBackColor = true;
            // 
            // radioButton_easy
            // 
            this.radioButton_easy.AutoSize = true;
            this.radioButton_easy.Location = new System.Drawing.Point(37, 42);
            this.radioButton_easy.Name = "radioButton_easy";
            this.radioButton_easy.Size = new System.Drawing.Size(48, 17);
            this.radioButton_easy.TabIndex = 0;
            this.radioButton_easy.TabStop = true;
            this.radioButton_easy.Text = "Easy";
            this.radioButton_easy.UseVisualStyleBackColor = true;
            // 
            // btn_startGame
            // 
            this.btn_startGame.Location = new System.Drawing.Point(162, 152);
            this.btn_startGame.Name = "btn_startGame";
            this.btn_startGame.Size = new System.Drawing.Size(103, 36);
            this.btn_startGame.TabIndex = 1;
            this.btn_startGame.Text = "Play Game!";
            this.btn_startGame.UseVisualStyleBackColor = true;
            this.btn_startGame.Click += new System.EventHandler(this.btn_startGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 192);
            this.Controls.Add(this.btn_startGame);
            this.Controls.Add(this.groupBox_DifficultySelection);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox_DifficultySelection.ResumeLayout(false);
            this.groupBox_DifficultySelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_DifficultySelection;
        private System.Windows.Forms.Button btn_startGame;
        private System.Windows.Forms.RadioButton radioButton_difficult;
        private System.Windows.Forms.RadioButton radioButton_moderate;
        private System.Windows.Forms.RadioButton radioButton_easy;
    }
}

