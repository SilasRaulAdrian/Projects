namespace Rock_Paper_Scissors
{
    partial class MainForm
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
            this.btnRock = new System.Windows.Forms.Button();
            this.btnPaper = new System.Windows.Forms.Button();
            this.btnScissors = new System.Windows.Forms.Button();
            this.CPU_PIC = new System.Windows.Forms.PictureBox();
            this.PLAYER_PIC = new System.Windows.Forms.PictureBox();
            this.lblCPUchoice = new System.Windows.Forms.Label();
            this.lblPlayerChoice = new System.Windows.Forms.Label();
            this.lblPlayerResult = new System.Windows.Forms.Label();
            this.lblCPUresult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CPU_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLAYER_PIC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRock
            // 
            this.btnRock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRock.Location = new System.Drawing.Point(71, 375);
            this.btnRock.Name = "btnRock";
            this.btnRock.Size = new System.Drawing.Size(134, 46);
            this.btnRock.TabIndex = 0;
            this.btnRock.Tag = "R";
            this.btnRock.Text = "Rock";
            this.btnRock.UseVisualStyleBackColor = true;
            this.btnRock.Click += new System.EventHandler(this.MakeChoiceEvent);
            // 
            // btnPaper
            // 
            this.btnPaper.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaper.Location = new System.Drawing.Point(326, 375);
            this.btnPaper.Name = "btnPaper";
            this.btnPaper.Size = new System.Drawing.Size(134, 46);
            this.btnPaper.TabIndex = 0;
            this.btnPaper.Tag = "P";
            this.btnPaper.Text = "Paper";
            this.btnPaper.UseVisualStyleBackColor = true;
            this.btnPaper.Click += new System.EventHandler(this.MakeChoiceEvent);
            // 
            // btnScissors
            // 
            this.btnScissors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScissors.Location = new System.Drawing.Point(569, 375);
            this.btnScissors.Name = "btnScissors";
            this.btnScissors.Size = new System.Drawing.Size(134, 46);
            this.btnScissors.TabIndex = 0;
            this.btnScissors.Tag = "S";
            this.btnScissors.Text = "Scissors";
            this.btnScissors.UseVisualStyleBackColor = true;
            this.btnScissors.Click += new System.EventHandler(this.MakeChoiceEvent);
            // 
            // CPU_PIC
            // 
            this.CPU_PIC.Location = new System.Drawing.Point(346, 55);
            this.CPU_PIC.Name = "CPU_PIC";
            this.CPU_PIC.Size = new System.Drawing.Size(100, 100);
            this.CPU_PIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CPU_PIC.TabIndex = 1;
            this.CPU_PIC.TabStop = false;
            // 
            // PLAYER_PIC
            // 
            this.PLAYER_PIC.Location = new System.Drawing.Point(346, 213);
            this.PLAYER_PIC.Name = "PLAYER_PIC";
            this.PLAYER_PIC.Size = new System.Drawing.Size(100, 100);
            this.PLAYER_PIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PLAYER_PIC.TabIndex = 1;
            this.PLAYER_PIC.TabStop = false;
            // 
            // lblCPUchoice
            // 
            this.lblCPUchoice.AutoSize = true;
            this.lblCPUchoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPUchoice.ForeColor = System.Drawing.Color.White;
            this.lblCPUchoice.Location = new System.Drawing.Point(284, 9);
            this.lblCPUchoice.Name = "lblCPUchoice";
            this.lblCPUchoice.Size = new System.Drawing.Size(154, 20);
            this.lblCPUchoice.TabIndex = 2;
            this.lblCPUchoice.Text = "Computer Choice";
            // 
            // lblPlayerChoice
            // 
            this.lblPlayerChoice.AutoSize = true;
            this.lblPlayerChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerChoice.ForeColor = System.Drawing.Color.White;
            this.lblPlayerChoice.Location = new System.Drawing.Point(284, 330);
            this.lblPlayerChoice.Name = "lblPlayerChoice";
            this.lblPlayerChoice.Size = new System.Drawing.Size(126, 20);
            this.lblPlayerChoice.TabIndex = 2;
            this.lblPlayerChoice.Text = "Player Choice";
            // 
            // lblPlayerResult
            // 
            this.lblPlayerResult.AutoSize = true;
            this.lblPlayerResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerResult.ForeColor = System.Drawing.Color.White;
            this.lblPlayerResult.Location = new System.Drawing.Point(67, 156);
            this.lblPlayerResult.Name = "lblPlayerResult";
            this.lblPlayerResult.Size = new System.Drawing.Size(122, 20);
            this.lblPlayerResult.TabIndex = 2;
            this.lblPlayerResult.Text = "Player Result";
            // 
            // lblCPUresult
            // 
            this.lblCPUresult.AutoSize = true;
            this.lblCPUresult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPUresult.ForeColor = System.Drawing.Color.White;
            this.lblCPUresult.Location = new System.Drawing.Point(565, 156);
            this.lblCPUresult.Name = "lblCPUresult";
            this.lblCPUresult.Size = new System.Drawing.Size(150, 20);
            this.lblCPUresult.TabIndex = 2;
            this.lblCPUresult.Text = "Computer Result";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCPUresult);
            this.Controls.Add(this.lblPlayerResult);
            this.Controls.Add(this.lblPlayerChoice);
            this.Controls.Add(this.lblCPUchoice);
            this.Controls.Add(this.PLAYER_PIC);
            this.Controls.Add(this.CPU_PIC);
            this.Controls.Add(this.btnScissors);
            this.Controls.Add(this.btnPaper);
            this.Controls.Add(this.btnRock);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rock Paper Scissors";
            ((System.ComponentModel.ISupportInitialize)(this.CPU_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLAYER_PIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRock;
        private System.Windows.Forms.Button btnPaper;
        private System.Windows.Forms.Button btnScissors;
        private System.Windows.Forms.PictureBox CPU_PIC;
        private System.Windows.Forms.PictureBox PLAYER_PIC;
        private System.Windows.Forms.Label lblCPUchoice;
        private System.Windows.Forms.Label lblPlayerChoice;
        private System.Windows.Forms.Label lblPlayerResult;
        private System.Windows.Forms.Label lblCPUresult;
    }
}

