using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int Ball_x = 4;
        int Ball_y = 4;
        int score = 40;
        int life = 3;
        private void Game_Over()
        {
            if (score == 88)
            {
                timer1.Stop();
                MessageBox.Show("You Win! Last Stage!");
            }
            if (ball.Top + ball.Height > ClientSize.Height)
            {
                timer1.Stop();
                DialogResult DialogResult = MessageBox.Show("GAME OVER", "Use Life? ", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    timer1.Start();
                    Ball_Movement2();
                    life--;
                    ball.Left -= 40;
                    ball.Top -= 40;
                    Ball_Movement();
                    lbl_life.Text = "Life : " + life;
                    if (life < 0)
                    {
                        timer1.Start();
                        Ball_Movement2();
                        life--;
                        ball.Left -= 10000;
                        ball.Top -= 10000;
                        Ball_Movement();
                        MessageBox.Show("GAME OVER");
                        Form2 game = new Form2();
                        this.SetVisibleCore(false);
                        game.Show();
                    }
                }
                if (DialogResult == DialogResult.No)
                {
                    Form2 game = new Form2();
                    this.SetVisibleCore(false);
                    game.Show();
                }
            }
        }
        private void Get_Score()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        Ball_y = -Ball_y;
                        score++;
                        lbl_score.Text = "Score : " + score;
                    }
                }
            }
        }
        private void Ball_Movement()
        {
            ball.Left += Ball_x;
            ball.Top += Ball_y;
            if (ball.Left + ball.Width > ClientSize.Width || ball.Left < 0)
            {
                Ball_x = -Ball_x;
            }
            if (ball.Top < 0 || ball.Bounds.IntersectsWith(player.Bounds))
            {
                Ball_y = -Ball_y;
            }
        }
        private void Ball_Movement2()
        {
            ball.Left += Ball_x;
            ball.Top += Ball_y;
            if (ball.Left + ball.Width > ClientSize.Width || ball.Left < 0)
            {
                Ball_x = -Ball_x;
            }
            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                Ball_y = -Ball_y;
            }
        }
        private void Arkanoid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && player.Left > 0)
            {
                player.Left -= 5;
            }
            if (e.KeyCode == Keys.Right && player.Right < 320)
            {
                player.Left += 5;
            }
        }
        private new void Load()
        {
            if (score == 88)
            {
                Form4 game = new Form4();
                this.SetVisibleCore(false);
                game.Show();
            }
        }
        private void Main(object sender, EventArgs e)
        {
            Ball_Movement();
            Get_Score();
            Game_Over();
            Load();
        }
    }
}
