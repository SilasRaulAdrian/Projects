namespace FlappyBird
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
            this.components = new System.ComponentModel.Container();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pbBird = new System.Windows.Forms.PictureBox();
            this.pbPipeTop = new System.Windows.Forms.PictureBox();
            this.pbGround = new System.Windows.Forms.PictureBox();
            this.pbPipeBottom = new System.Windows.Forms.PictureBox();
            this.pbRestart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPipeTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPipeBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(32, 636);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(128, 33);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Score: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // pbBird
            // 
            this.pbBird.Image = global::FlappyBird.Properties.Resources.bird;
            this.pbBird.Location = new System.Drawing.Point(21, 187);
            this.pbBird.Name = "pbBird";
            this.pbBird.Size = new System.Drawing.Size(68, 59);
            this.pbBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBird.TabIndex = 0;
            this.pbBird.TabStop = false;
            // 
            // pbPipeTop
            // 
            this.pbPipeTop.Image = global::FlappyBird.Properties.Resources.pipedown;
            this.pbPipeTop.Location = new System.Drawing.Point(496, -98);
            this.pbPipeTop.Name = "pbPipeTop";
            this.pbPipeTop.Size = new System.Drawing.Size(100, 267);
            this.pbPipeTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPipeTop.TabIndex = 0;
            this.pbPipeTop.TabStop = false;
            // 
            // pbGround
            // 
            this.pbGround.BackColor = System.Drawing.Color.Transparent;
            this.pbGround.BackgroundImage = global::FlappyBird.Properties.Resources.ground;
            this.pbGround.Location = new System.Drawing.Point(1, 594);
            this.pbGround.Name = "pbGround";
            this.pbGround.Size = new System.Drawing.Size(620, 168);
            this.pbGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGround.TabIndex = 0;
            this.pbGround.TabStop = false;
            // 
            // pbPipeBottom
            // 
            this.pbPipeBottom.Image = global::FlappyBird.Properties.Resources.pipe;
            this.pbPipeBottom.Location = new System.Drawing.Point(389, 386);
            this.pbPipeBottom.Name = "pbPipeBottom";
            this.pbPipeBottom.Size = new System.Drawing.Size(100, 319);
            this.pbPipeBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPipeBottom.TabIndex = 0;
            this.pbPipeBottom.TabStop = false;
            // 
            // pbRestart
            // 
            this.pbRestart.Image = global::FlappyBird.Properties.Resources.restart;
            this.pbRestart.Location = new System.Drawing.Point(253, 168);
            this.pbRestart.Name = "pbRestart";
            this.pbRestart.Size = new System.Drawing.Size(150, 150);
            this.pbRestart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRestart.TabIndex = 2;
            this.pbRestart.TabStop = false;
            this.pbRestart.Click += new System.EventHandler(this.pbRestart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(620, 699);
            this.Controls.Add(this.pbRestart);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbBird);
            this.Controls.Add(this.pbPipeTop);
            this.Controls.Add(this.pbGround);
            this.Controls.Add(this.pbPipeBottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flappy Bird";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbBird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPipeTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPipeBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGround;
        private System.Windows.Forms.PictureBox pbBird;
        private System.Windows.Forms.PictureBox pbPipeTop;
        private System.Windows.Forms.PictureBox pbPipeBottom;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox pbRestart;
    }
}

