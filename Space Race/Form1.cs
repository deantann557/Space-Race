using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Race
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(125, 170, 30, 30);
         Rectangle player2 = new Rectangle(450, 170, 30, 30);

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush beigeBrush = new SolidBrush(Color.Beige);

        int player1Speed = 6;
        int player2Speed = 6;

        int player1Score = 0;
        int player2Score = 0;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        Random randGen = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            P1PointLabel.Text = $"Player 1: {player1Score}";
            P2PointLabel.Text = $"Player 2: {player2Score}";
           

            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(beigeBrush, player2);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (wDown == true && player1.Y > 2)
            {
                player1.Y -= player1Speed;
            }
            if (sDown == true && player1.Y < 334)
            {
                player1.Y += player1Speed;
            }
            if (player1.Y < 3)
            {
                player1.Y = randGen.Next(333, 334);
                player1Score++;
            }

            if (upArrowDown == true && player2.Y > 2)
            {
                player2.Y -= player2Speed;
            }
            if (downArrowDown == true && player2.Y < 334)
            {
                player2.Y += player2Speed;
            }
            if (player2.Y < 3)
            {
                player2.Y = randGen.Next(333, 334);
                player2Score++;
            }

            if (player1Score == 5)
            {
                gameTimer.Enabled = false;
                VictoryLabel.Visible = true;
                VictoryLabel.Text = "Player 1 Wins!!";  
            }
            else if (player2Score == 5)
            {
                gameTimer.Enabled = false;
                VictoryLabel.Visible = true;
                VictoryLabel.Text = "Player 2 Wins!!";
            }
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }


            {

                {

                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

       
    }
}

