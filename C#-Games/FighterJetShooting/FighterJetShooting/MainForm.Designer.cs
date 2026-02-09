namespace FighterJetShooting
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
            this.pbEnemy1 = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.pbBullet = new System.Windows.Forms.PictureBox();
            this.pbEnemy2 = new System.Windows.Forms.PictureBox();
            this.pbEnemy3 = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy3)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEnemy1
            // 
            this.pbEnemy1.Image = global::FighterJetShooting.Properties.Resources.enemy;
            this.pbEnemy1.Location = new System.Drawing.Point(49, 64);
            this.pbEnemy1.Name = "pbEnemy1";
            this.pbEnemy1.Size = new System.Drawing.Size(100, 85);
            this.pbEnemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEnemy1.TabIndex = 0;
            this.pbEnemy1.TabStop = false;
            // 
            // pbPlayer
            // 
            this.pbPlayer.Image = global::FighterJetShooting.Properties.Resources.player;
            this.pbPlayer.Location = new System.Drawing.Point(322, 556);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(110, 98);
            this.pbPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPlayer.TabIndex = 0;
            this.pbPlayer.TabStop = false;
            // 
            // pbBullet
            // 
            this.pbBullet.Image = global::FighterJetShooting.Properties.Resources.bullet;
            this.pbBullet.Location = new System.Drawing.Point(373, 446);
            this.pbBullet.Name = "pbBullet";
            this.pbBullet.Size = new System.Drawing.Size(7, 27);
            this.pbBullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBullet.TabIndex = 0;
            this.pbBullet.TabStop = false;
            // 
            // pbEnemy2
            // 
            this.pbEnemy2.Image = global::FighterJetShooting.Properties.Resources.enemy;
            this.pbEnemy2.Location = new System.Drawing.Point(332, 64);
            this.pbEnemy2.Name = "pbEnemy2";
            this.pbEnemy2.Size = new System.Drawing.Size(100, 85);
            this.pbEnemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEnemy2.TabIndex = 0;
            this.pbEnemy2.TabStop = false;
            // 
            // pbEnemy3
            // 
            this.pbEnemy3.Image = global::FighterJetShooting.Properties.Resources.enemy;
            this.pbEnemy3.Location = new System.Drawing.Point(622, 64);
            this.pbEnemy3.Name = "pbEnemy3";
            this.pbEnemy3.Size = new System.Drawing.Size(100, 85);
            this.pbEnemy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEnemy3.TabIndex = 0;
            this.pbEnemy3.TabStop = false;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(12, 247);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(774, 149);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(798, 666);
            this.Controls.Add(this.pbEnemy3);
            this.Controls.Add(this.pbEnemy2);
            this.Controls.Add(this.pbBullet);
            this.Controls.Add(this.pbPlayer);
            this.Controls.Add(this.pbEnemy1);
            this.Controls.Add(this.lblScore);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fighter Jet Shooting";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemy3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEnemy1;
        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.PictureBox pbBullet;
        private System.Windows.Forms.PictureBox pbEnemy2;
        private System.Windows.Forms.PictureBox pbEnemy3;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer gameTimer;
    }
}

