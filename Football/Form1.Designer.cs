namespace Football
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
            this.footballGame4 = new Football.FootballGame();
            this.footballGame3 = new Football.FootballGame();
            this.footballGame2 = new Football.FootballGame();
            this.footballGame1 = new Football.FootballGame();
            this.playGamesButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // footballGame4
            // 
            this.footballGame4.Location = new System.Drawing.Point(346, 162);
            this.footballGame4.Name = "footballGame4";
            this.footballGame4.Size = new System.Drawing.Size(305, 144);
            this.footballGame4.TabIndex = 3;
            // 
            // footballGame3
            // 
            this.footballGame3.Location = new System.Drawing.Point(346, 12);
            this.footballGame3.Name = "footballGame3";
            this.footballGame3.Size = new System.Drawing.Size(305, 144);
            this.footballGame3.TabIndex = 2;
            // 
            // footballGame2
            // 
            this.footballGame2.Location = new System.Drawing.Point(12, 162);
            this.footballGame2.Name = "footballGame2";
            this.footballGame2.Size = new System.Drawing.Size(305, 144);
            this.footballGame2.TabIndex = 1;
            // 
            // footballGame1
            // 
            this.footballGame1.Location = new System.Drawing.Point(12, 12);
            this.footballGame1.Name = "footballGame1";
            this.footballGame1.Size = new System.Drawing.Size(305, 144);
            this.footballGame1.TabIndex = 0;
            // 
            // playGamesButton
            // 
            this.playGamesButton.Location = new System.Drawing.Point(714, 148);
            this.playGamesButton.Name = "playGamesButton";
            this.playGamesButton.Size = new System.Drawing.Size(107, 23);
            this.playGamesButton.TabIndex = 4;
            this.playGamesButton.Text = "Play Games";
            this.playGamesButton.UseVisualStyleBackColor = true;
            this.playGamesButton.Click += new System.EventHandler(this.PlayGamesButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(714, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Play 100 Seasons";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Play100Seasons);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 378);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playGamesButton);
            this.Controls.Add(this.footballGame4);
            this.Controls.Add(this.footballGame3);
            this.Controls.Add(this.footballGame2);
            this.Controls.Add(this.footballGame1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private FootballGame footballGame1;
        private FootballGame footballGame2;
        private FootballGame footballGame3;
        private FootballGame footballGame4;
        private System.Windows.Forms.Button playGamesButton;
        private System.Windows.Forms.Button button1;
    }
}

