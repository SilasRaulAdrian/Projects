using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizGame
{
    public partial class MainForm : Form
    {
        int correctAnswer;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;
        public MainForm()
        {
            InitializeComponent();

            AskQuestion(questionNumber);

            totalQuestions = 8;
        }

        private void CheckAnswerEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if (buttonTag == correctAnswer)
            {
                score++;
            }

            if (questionNumber == totalQuestions) 
            {
                percentage = (int)Math.Round((double)(score * 100) / totalQuestions);
                MessageBox.Show("Quiz Ended!" + Environment.NewLine +
                    "You have answered " + score + " questions correctly." + Environment.NewLine +
                    "Your total percentage is " + percentage + "%" + Environment.NewLine + 
                    "Click OK to play again");
                score = 0;
                questionNumber = 0;
                AskQuestion(questionNumber);
            }

            questionNumber++;
            AskQuestion(questionNumber);
        }

        private void AskQuestion(int qnum)
        {
            switch(qnum)
            {
                case 1:
                    pbImages.Image = Properties.Resources.salah;
                    lblQuestion.Text = "Who is this player?";
                    btnFirst.Text = "Ronaldo";
                    btnSecond.Text = "Salah";
                    btnThird.Text = "Ramos";
                    btnFourth.Text = "Neymar";
                    correctAnswer = 2;
                    break;
                case 2:
                    pbImages.Image = Properties.Resources.ronaldo;
                    lblQuestion.Text = "Who is this player?";
                    btnFirst.Text = "Ronaldo";
                    btnSecond.Text = "Messi";
                    btnThird.Text = "Carl";
                    btnFourth.Text = "Lewandowski";
                    correctAnswer = 1;
                    break;
                case 3:
                    pbImages.Image = Properties.Resources.ronaldinho;
                    lblQuestion.Text = "Who is this player?";
                    btnFirst.Text = "Ronaldo";
                    btnSecond.Text = "Messi";
                    btnThird.Text = "Neymar";
                    btnFourth.Text = "Ronaldinho";
                    correctAnswer = 4;
                    break;
                case 4:
                    pbImages.Image = Properties.Resources.ramos;
                    lblQuestion.Text = "Who is this player?";
                    btnFirst.Text = "Ronaldo";
                    btnSecond.Text = "Salah";
                    btnThird.Text = "Ramos";
                    btnFourth.Text = "Neymar";
                    correctAnswer = 3;
                    break;
                case 5:
                    pbImages.Image = Properties.Resources.neymar;
                    lblQuestion.Text = "Who is this player?";
                    btnFirst.Text = "Ronaldo";
                    btnSecond.Text = "Messi";
                    btnThird.Text = "Carl";
                    btnFourth.Text = "Neymar";
                    correctAnswer = 4;
                    break;
                case 6:
                    pbImages.Image = Properties.Resources.messi;
                    lblQuestion.Text = "Who is this player?";
                    btnFirst.Text = "Messi";
                    btnSecond.Text = "Ronaldinho";
                    btnThird.Text = "Ramos";
                    btnFourth.Text = "Lewandowski";
                    correctAnswer = 1;
                    break;
                case 7:
                    pbImages.Image = Properties.Resources.lewandowski;
                    lblQuestion.Text = "Who is this player?";
                    btnFirst.Text = "Carl";
                    btnSecond.Text = "Salah";
                    btnThird.Text = "Lewandowski";
                    btnFourth.Text = "Ronaldo";
                    correctAnswer = 3;
                    break;
                case 8:
                    pbImages.Image = Properties.Resources.carl;
                    lblQuestion.Text = "Who is this player?";
                    btnFirst.Text = "Ronaldo";
                    btnSecond.Text = "Carl";
                    btnThird.Text = "Salah";
                    btnFourth.Text = "Ronaldinho";
                    correctAnswer = 2;
                    break;
            }
        }
    }
}
