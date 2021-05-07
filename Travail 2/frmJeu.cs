using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travail_2
{
    public partial class frmJeu : Form
    {
        Bitmap backgroundImage;
        Bitmap spaceshipImage;
        Bitmap asteroidImage;
        Bitmap laserImage;
        Bitmap gameImage;

        ManagerJeu managerJeu;

        public frmJeu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            managerJeu = new ManagerJeu(this.Width,this.Height);
            
            Image background = Image.FromFile("../../Images/bg_space_seamless_1.png");
            Image spaceship = Image.FromFile("../../Images/flashtestship.png");
            Image laser = Image.FromFile("../../Images/laser_beam.png");
            Image asteroid = Image.FromFile("../../Images/Asteroid.png");

            backgroundImage = new Bitmap(background, managerJeu.GetMapWidth(), managerJeu.GetMapHeight());
            spaceshipImage = new Bitmap(spaceship, managerJeu.GetPlayerInput().GetPlayerWidth(), managerJeu.GetPlayerInput().GetPlayerHeight());
            laserImage = new Bitmap(laser, managerJeu.GetLaser().GetLaserWidth(), managerJeu.GetLaser().GetLaserHeight());

            //for (int i = 0; i < managerJeu.GetEnemies().Count; i++)
            //{
            //    asteroidImage = new Bitmap(asteroid, managerJeu.GetEnemies()[i].GetAsteroidWidth(), managerJeu.GetEnemies()[i].GetAsteroidHeight());
            //}

            //Enemies nouveauAsteroid = new Enemies();
            //for (int i = 0; i < 5; i++)
            //{
            //    managerJeu.GetEnemies().Add(nouveauAsteroid);
            //}
            //MessageBox.Show(managerJeu.GetEnemies().Count().ToString());

            gameImage = new Bitmap(this.Width, this.Height);

            managerJeu.GetPlayerInput().SetPositionX(this.Width / 2 - managerJeu.GetPlayerInput().GetPlayerWidth() / 2);
            managerJeu.GetPlayerInput().SetPositionY(this.Height / 2 - managerJeu.GetPlayerInput().GetPlayerHeight() / 2);
            managerJeu.GetEnemies().Add(new Enemies());

            GameTimer.Start();
        }
        private void Draw()
        {
            gameImage.Dispose();
            gameImage = new Bitmap(this.Width, this.Height);

            using (Graphics graphics = Graphics.FromImage(gameImage))
            {
                graphics.DrawImage(backgroundImage, 0, 0);
                graphics.DrawImage(spaceshipImage, managerJeu.GetPlayerInput().GetPositionX(), managerJeu.GetPlayerInput().GetPositionY());

                //for (int i = 0; i < managerJeu.GetEnemies().Count; i++)
                //{
                //    graphics.DrawImage(asteroidImage, managerJeu.GetEnemies()[i].GetAsteroidPositionX(), managerJeu.GetEnemies()[i].GetAsteroidPositionY());
                //}
            }

            this.BackgroundImage = gameImage;
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (managerJeu.GetPlayerInput().GetGoLeft())
            {
                if (managerJeu.GetPlayerInput().GetPositionX() > 0)
                {
                    managerJeu.GetPlayerInput().SetPositionX(managerJeu.GetPlayerInput().GetPositionX() - managerJeu.GetPlayerInput().GetPlayerSpeed());
                }
            }
            else if (managerJeu.GetPlayerInput().GetGoRight())
            {
                if (managerJeu.GetPlayerInput().GetPositionX() < this.Width - managerJeu.GetPlayerInput().GetPlayerWidth())
                {
                    managerJeu.GetPlayerInput().SetPositionX(managerJeu.GetPlayerInput().GetPositionX() + managerJeu.GetPlayerInput().GetPlayerSpeed());
                }
            }
            if (managerJeu.GetPlayerInput().GetGoUp())
            {
                if (managerJeu.GetPlayerInput().GetPositionY() > 0)
                {
                    managerJeu.GetPlayerInput().SetPositionY(managerJeu.GetPlayerInput().GetPositionY() - managerJeu.GetPlayerInput().GetPlayerSpeed());
                }
            }
            else if (managerJeu.GetPlayerInput().GetGoDown())
            {
                if (managerJeu.GetPlayerInput().GetPositionY() < this.Height - managerJeu.GetPlayerInput().GetPlayerHeight())
                {
                    managerJeu.GetPlayerInput().SetPositionY(managerJeu.GetPlayerInput().GetPositionY() + managerJeu.GetPlayerInput().GetPlayerSpeed());
                }
            }
            for (int i = 0; i < managerJeu.GetEnemies().Count; i++)
            {
                managerJeu.GetEnemies()[i].ChangerPositionY();
            }
            Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                managerJeu.GetPlayerInput().SetGoLeft(true);
            }
            else if (e.KeyCode == Keys.Right)
            {
                managerJeu.GetPlayerInput().SetGoRight(true);
            }
            else if (e.KeyCode == Keys.Up)
            {
                managerJeu.GetPlayerInput().SetGoUp(true);
            }
            else if (e.KeyCode == Keys.Down)
            {
                managerJeu.GetPlayerInput().SetGoDown(true);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
            else if (e.KeyCode == Keys.Space)
            {
                managerJeu.GetLaser().Fire();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                managerJeu.GetPlayerInput().SetGoLeft(false);
            }
            else if (e.KeyCode == Keys.Right)
            {
                managerJeu.GetPlayerInput().SetGoRight(false);
            }
            else if (e.KeyCode == Keys.Up)
            {
                managerJeu.GetPlayerInput().SetGoUp(false);
            }
            else if (e.KeyCode == Keys.Down)
            {
                managerJeu.GetPlayerInput().SetGoDown(false);
            }
        }
    }
}
