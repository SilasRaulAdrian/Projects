namespace QuizGame
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
            this.pbImages = new System.Windows.Forms.PictureBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnSecond = new System.Windows.Forms.Button();
            this.btnThird = new System.Windows.Forms.Button();
            this.btnFourth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImages)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImages
            // 
            this.pbImages.Location = new System.Drawing.Point(13, 13);
            this.pbImages.Name = "pbImages";
            this.pbImages.Size = new System.Drawing.Size(773, 302);
            this.pbImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImages.TabIndex = 0;
            this.pbImages.TabStop = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(13, 341);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(773, 45);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "Question";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(34, 411);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(247, 59);
            this.btnFirst.TabIndex = 2;
            this.btnFirst.Tag = "1";
            this.btnFirst.Text = "button1";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.CheckAnswerEvent);
            // 
            // btnSecond
            // 
            this.btnSecond.Location = new System.Drawing.Point(506, 411);
            this.btnSecond.Name = "btnSecond";
            this.btnSecond.Size = new System.Drawing.Size(247, 59);
            this.btnSecond.TabIndex = 3;
            this.btnSecond.Tag = "2";
            this.btnSecond.Text = "button2";
            this.btnSecond.UseVisualStyleBackColor = true;
            this.btnSecond.Click += new System.EventHandler(this.CheckAnswerEvent);
            // 
            // btnThird
            // 
            this.btnThird.Location = new System.Drawing.Point(34, 497);
            this.btnThird.Name = "btnThird";
            this.btnThird.Size = new System.Drawing.Size(247, 59);
            this.btnThird.TabIndex = 5;
            this.btnThird.Tag = "3";
            this.btnThird.Text = "button3";
            this.btnThird.UseVisualStyleBackColor = true;
            this.btnThird.Click += new System.EventHandler(this.CheckAnswerEvent);
            // 
            // btnFourth
            // 
            this.btnFourth.Location = new System.Drawing.Point(506, 497);
            this.btnFourth.Name = "btnFourth";
            this.btnFourth.Size = new System.Drawing.Size(247, 59);
            this.btnFourth.TabIndex = 4;
            this.btnFourth.Tag = "4";
            this.btnFourth.Text = "button4";
            this.btnFourth.UseVisualStyleBackColor = true;
            this.btnFourth.Click += new System.EventHandler(this.CheckAnswerEvent);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 593);
            this.Controls.Add(this.btnThird);
            this.Controls.Add(this.btnFourth);
            this.Controls.Add(this.btnSecond);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.pbImages);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz Game";
            ((System.ComponentModel.ISupportInitialize)(this.pbImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImages;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSecond;
        private System.Windows.Forms.Button btnThird;
        private System.Windows.Forms.Button btnFourth;
    }
}

