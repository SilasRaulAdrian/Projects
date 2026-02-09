namespace Boxing
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
            this.boxerHealthBar = new System.Windows.Forms.ProgressBar();
            this.playerHealthBar = new System.Windows.Forms.ProgressBar();
            this.player = new System.Windows.Forms.PictureBox();
            this.boxer = new System.Windows.Forms.PictureBox();
            this.boxerAttackTimer = new System.Windows.Forms.Timer(this.components);
            this.boxerMoveTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxer)).BeginInit();
            this.SuspendLayout();
            // 
            // boxerHealthBar
            // 
            this.boxerHealthBar.Location = new System.Drawing.Point(39, 43);
            this.boxerHealthBar.Name = "boxerHealthBar";
            this.boxerHealthBar.Size = new System.Drawing.Size(195, 23);
            this.boxerHealthBar.TabIndex = 0;
            // 
            // playerHealthBar
            // 
            this.playerHealthBar.Location = new System.Drawing.Point(494, 43);
            this.playerHealthBar.Name = "playerHealthBar";
            this.playerHealthBar.Size = new System.Drawing.Size(195, 23);
            this.playerHealthBar.TabIndex = 0;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::Boxing.Properties.Resources.boxer_stand;
            this.player.Location = new System.Drawing.Point(341, 365);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(61, 153);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 1;
            this.player.TabStop = false;
            // 
            // boxer
            // 
            this.boxer.BackColor = System.Drawing.Color.Transparent;
            this.boxer.Image = global::Boxing.Properties.Resources.enemy_stand;
            this.boxer.Location = new System.Drawing.Point(408, 265);
            this.boxer.Name = "boxer";
            this.boxer.Size = new System.Drawing.Size(77, 185);
            this.boxer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.boxer.TabIndex = 2;
            this.boxer.TabStop = false;
            // 
            // boxerAttackTimer
            // 
            this.boxerAttackTimer.Enabled = true;
            this.boxerAttackTimer.Interval = 500;
            this.boxerAttackTimer.Tick += new System.EventHandler(this.boxerAttackTimer_Tick);
            // 
            // boxerMoveTimer
            // 
            this.boxerMoveTimer.Enabled = true;
            this.boxerMoveTimer.Interval = 20;
            this.boxerMoveTimer.Tick += new System.EventHandler(this.boxerMoveTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Boxing.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(732, 553);
            this.Controls.Add(this.player);
            this.Controls.Add(this.playerHealthBar);
            this.Controls.Add(this.boxerHealthBar);
            this.Controls.Add(this.boxer);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boxing";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar boxerHealthBar;
        private System.Windows.Forms.ProgressBar playerHealthBar;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox boxer;
        private System.Windows.Forms.Timer boxerAttackTimer;
        private System.Windows.Forms.Timer boxerMoveTimer;
    }
}

