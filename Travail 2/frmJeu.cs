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
        private Bitmap backgroundImage;
        private Bitmap spaceshipImage;
        private Bitmap asteroidImage;
        private Bitmap laserImage;
        private Bitmap gameImage;
        private Random random = new Random();
        private ManagerJeu managerJeu;
        private RectangleF playerHitbox;
        private List<RectangleF> ennemiesHitbox;
        private RectangleF laserHitbox;

        public frmJeu(ManagerJeu managerJeu)
        {
            InitializeComponent();
            this.managerJeu = managerJeu;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image background = Image.FromFile("../../Images/bg_space_seamless_1.png");
            Image spaceship = Image.FromFile("../../Images/flashtestship.png");
            Image laser = Image.FromFile("../../Images/laser_beam.png");
            Image asteroid = Image.FromFile("../../Images/Asteroid.png");

            backgroundImage = new Bitmap(background, managerJeu.GetMapWidth(), managerJeu.GetMapHeight());
            spaceshipImage = new Bitmap(spaceship, managerJeu.GetPlayerInput().GetPlayerWidth(), managerJeu.GetPlayerInput().GetPlayerHeight());
            laserImage = new Bitmap(laser, managerJeu.GetLaser().GetLaserWidth(), managerJeu.GetLaser().GetLaserHeight());

            playerHitbox = new RectangleF(50, 50, managerJeu.GetPlayerInput().GetPlayerWidth(), managerJeu.GetPlayerInput().GetPlayerHeight());
            laserHitbox = new RectangleF(50, 50, managerJeu.GetLaser().GetLaserWidth(), managerJeu.GetLaser().GetLaserHeight());
            ennemiesHitbox = new List<RectangleF>();

            gameImage = new Bitmap(this.Width, this.Height);

            managerJeu.GetEnemies().Clear();
            for (int i = 0; i < 10; i++)
            {
                Enemies nouveauAsteroid = new Enemies(random.Next(0, this.Width), random.Next(5, 10) * managerJeu.GetDifficulte());
                managerJeu.GetEnemies().Add(nouveauAsteroid);
            }

            for (int i = 0; i < 10; i++)
            {
                RectangleF nouveauHitboxAsteroid = new RectangleF(0, 0, managerJeu.GetEnemies()[i].GetAsteroidWidth(), managerJeu.GetEnemies()[i].GetAsteroidHeight());
                nouveauHitboxAsteroid.Width = managerJeu.GetEnemies()[i].GetAsteroidWidth();
                nouveauHitboxAsteroid.Height = managerJeu.GetEnemies()[i].GetAsteroidHeight();
                ennemiesHitbox.Add(nouveauHitboxAsteroid);
            }

            for (int i = 0; i < managerJeu.GetEnemies().Count; i++)
            {
                asteroidImage = new Bitmap(asteroid, managerJeu.GetEnemies()[i].GetAsteroidWidth(), managerJeu.GetEnemies()[i].GetAsteroidHeight());                
            }

            managerJeu.GetPlayerInput().SetPositionX(this.Width / 2 - managerJeu.GetPlayerInput().GetPlayerWidth() / 2);
            managerJeu.GetPlayerInput().SetPositionY(this.Height - managerJeu.GetPlayerInput().GetPlayerHeight());

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

                for (int i = 0; i < managerJeu.GetEnemies().Count; i++)
                {
                    graphics.DrawImage(asteroidImage, managerJeu.GetEnemies()[i].GetAsteroidPositionX(), managerJeu.GetEnemies()[i].GetAsteroidPositionY());
                }
            }
            lblScore.Text = managerJeu.GetScore().ToString();

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
                if (managerJeu.GetEnemies()[i].GetAsteroidPositionY() > 720)
                {
                    managerJeu.GetEnemies()[i].RespawnEnemy(random.Next(0, this.Width), random.Next(5, 10) * managerJeu.GetDifficulte());
                }
            }
            for (int i = 0; i < ennemiesHitbox.Count; i++)
            {
                if (playerHitbox.IntersectsWith(ennemiesHitbox[i]))
                {
                    Gameover();
                }
            }
            UpdateHitboxes();
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
                managerJeu.GetEnemies().Clear();
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

        private void Gameover()
        {
            GameTimer.Stop();
            MessageBox.Show("Gameover! : " + managerJeu.GetScore());
            managerJeu.GetPlayerInput().SetGoLeft(false);
            managerJeu.GetPlayerInput().SetGoDown(false);
            managerJeu.GetPlayerInput().SetGoRight(false);
            managerJeu.GetPlayerInput().SetGoUp(false);
            this.Dispose();
            this.Close();
        }

        private void lblAddScore_Click(object sender, EventArgs e)
        {
            managerJeu.SetScore(50);
        }

        private void lblGameover_Click(object sender, EventArgs e)
        {
            Gameover();
        }

        private void UpdateHitboxes()
        {
            playerHitbox.X = managerJeu.GetPlayerInput().GetPositionX();
            playerHitbox.Y = managerJeu.GetPlayerInput().GetPositionY();
            laserHitbox.X = managerJeu.GetLaser().GetLaserPositionX();
            laserHitbox.Y = managerJeu.GetLaser().GetLaserPositionY();
            for (int i = 0; i < ennemiesHitbox.Count; i++)
            {
                RectangleF nouveauHitbox = ennemiesHitbox[i];
                nouveauHitbox.X = managerJeu.GetEnemies()[i].GetAsteroidPositionX();
                nouveauHitbox.Y = managerJeu.GetEnemies()[i].GetAsteroidPositionY();
                ennemiesHitbox[i] = nouveauHitbox;
            }
        }
    }
}
