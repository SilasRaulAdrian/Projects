namespace Play_Multiple_Sound_File
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnLaserSound = new System.Windows.Forms.Button();
            this.btnBackgroundSound = new System.Windows.Forms.Button();
            this.btnMediaPlayer = new System.Windows.Forms.Button();
            this.MXP = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.MXP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(731, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Play Multiple FIles Sounds Together with C#";
            // 
            // btnLaserSound
            // 
            this.btnLaserSound.Location = new System.Drawing.Point(113, 98);
            this.btnLaserSound.Name = "btnLaserSound";
            this.btnLaserSound.Size = new System.Drawing.Size(120, 96);
            this.btnLaserSound.TabIndex = 1;
            this.btnLaserSound.Text = "Play Laser Sound";
            this.btnLaserSound.UseVisualStyleBackColor = true;
            this.btnLaserSound.Click += new System.EventHandler(this.btnLaserSound_Click);
            // 
            // btnBackgroundSound
            // 
            this.btnBackgroundSound.Location = new System.Drawing.Point(593, 98);
            this.btnBackgroundSound.Name = "btnBackgroundSound";
            this.btnBackgroundSound.Size = new System.Drawing.Size(120, 96);
            this.btnBackgroundSound.TabIndex = 2;
            this.btnBackgroundSound.Text = "Play Background Music -\r\n Sound Player";
            this.btnBackgroundSound.UseVisualStyleBackColor = true;
            this.btnBackgroundSound.Click += new System.EventHandler(this.btnBackgroundSound_Click);
            // 
            // btnMediaPlayer
            // 
            this.btnMediaPlayer.Location = new System.Drawing.Point(338, 98);
            this.btnMediaPlayer.Name = "btnMediaPlayer";
            this.btnMediaPlayer.Size = new System.Drawing.Size(120, 96);
            this.btnMediaPlayer.TabIndex = 3;
            this.btnMediaPlayer.Text = "Play Background Music -\r\n Media Player";
            this.btnMediaPlayer.UseVisualStyleBackColor = true;
            this.btnMediaPlayer.Click += new System.EventHandler(this.btnMediaPlayer_Click);
            // 
            // MXP
            // 
            this.MXP.Enabled = true;
            this.MXP.Location = new System.Drawing.Point(174, 252);
            this.MXP.Name = "MXP";
            this.MXP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MXP.OcxState")));
            this.MXP.Size = new System.Drawing.Size(284, 70);
            this.MXP.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MXP);
            this.Controls.Add(this.btnMediaPlayer);
            this.Controls.Add(this.btnBackgroundSound);
            this.Controls.Add(this.btnLaserSound);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Play Multiple Sound File";
            ((System.ComponentModel.ISupportInitialize)(this.MXP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLaserSound;
        private System.Windows.Forms.Button btnBackgroundSound;
        private System.Windows.Forms.Button btnMediaPlayer;
        private AxWMPLib.AxWindowsMediaPlayer MXP;
    }
}

