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
        private List<RectangleF> ennemiesHitbox = new List<RectangleF>();
        private List<RectangleF> lasersHitbox = new List<RectangleF>();
        Image background = Image.FromFile("../../Images/bg_space_seamless_1.png");
        Image spaceship = Image.FromFile("../../Images/flashtestship.png");
        Image asteroid = Image.FromFile("../../Images/Asteroid.png");
        Image laser = Image.FromFile("../../Images/laser_beam.png");

        public frmJeu(ManagerJeu managerJeu)
        {
            InitializeComponent();
            this.managerJeu = managerJeu;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundImage = new Bitmap(background, managerJeu.GetMapWidth(), managerJeu.GetMapHeight());
            spaceshipImage = new Bitmap(spaceship, managerJeu.GetPlayerInput().GetPlayerWidth(), managerJeu.GetPlayerInput().GetPlayerHeight());
            gameImage = new Bitmap(this.Width, this.Height);

            playerHitbox = new RectangleF(50, 50, managerJeu.GetPlayerInput().GetPlayerWidth(), managerJeu.GetPlayerInput().GetPlayerHeight());

            managerJeu.GetPlayerInput().SetPositionX(this.Width / 2 - managerJeu.GetPlayerInput().GetPlayerWidth() / 2);
            managerJeu.GetPlayerInput().SetPositionY(this.Height - managerJeu.GetPlayerInput().GetPlayerHeight());

            managerJeu.GetEnemies().Clear();
            managerJeu.GetLasers().Clear();

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
                    asteroidImage = new Bitmap(asteroid, managerJeu.GetEnemies()[i].GetAsteroidWidth(), managerJeu.GetEnemies()[i].GetAsteroidHeight());
                    graphics.DrawImage(asteroidImage, managerJeu.GetEnemies()[i].GetAsteroidPositionX(), managerJeu.GetEnemies()[i].GetAsteroidPositionY());
                }
                for (int i = 0; i < managerJeu.GetLasers().Count; i++)
                {
                    graphics.DrawImage(laserImage, managerJeu.GetLasers()[i].GetPositionX(), managerJeu.GetLasers()[i].GetPositionY());
                }

            }
            lblScore.Text = managerJeu.GetScore().ToString();
            this.BackgroundImage = gameImage;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            managerJeu.SpawnEnemy(random.Next(0, this.Width), random.Next(5, 15) * managerJeu.GetDifficulte());
            GenerateEnemiesHitboxes();
            GenerateLasersHitboxes();
            UpdateHitboxes();
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
                if (managerJeu.GetEnemies()[i].GetAsteroidPositionY() > this.Height)
                {
                    managerJeu.GetEnemies().RemoveAt(i);
                    ennemiesHitbox.RemoveAt(i);
                }
            }

            for (int i = 0; i < ennemiesHitbox.Count; i++)
            {
                if (playerHitbox.IntersectsWith(ennemiesHitbox[i]))
                {
                    Gameover();
                }
            }

            managerJeu.DecreaseFireDelay();
            for (int i = 0; i < managerJeu.GetLasers().Count; i++)
            {
                managerJeu.GetLasers()[i].ChangerPositionY();
                if (managerJeu.GetLasers()[i].GetLaserPositionY() < 0)
                {
                    managerJeu.GetLasers().RemoveAt(i);
                    lasersHitbox.RemoveAt(i);
                }
            }

            for (int i = 0; i < lasersHitbox.Count; i++)
            {
                for (int j = 0; j < ennemiesHitbox.Count; j++)
                {
                    if (lasersHitbox[i].IntersectsWith(ennemiesHitbox[j]))
                    {
                        managerJeu.GetEnemies().RemoveAt(j);
                        managerJeu.GetLasers().RemoveAt(i);
                        managerJeu.AddPoints();
                    }
                }
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
                Gameover();
            }
            else if (e.KeyCode == Keys.Space)
            {
                managerJeu.Fire();
                for (int i = 0; i < managerJeu.GetLasers().Count; i++)
                {
                    laserImage = new Bitmap(laser, managerJeu.GetLasers()[i].GetLaserWidth(), managerJeu.GetLasers()[i].GetLaserHeight());
                }
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
            managerJeu.ResetPlayerInput();
            managerJeu.SetScore(0);
            this.Dispose();
            this.Close();
        }

        private void lblAddScore_Click(object sender, EventArgs e)
        {
            managerJeu.AddPoints();
        }

        private void lblGameover_Click(object sender, EventArgs e)
        {
            Gameover();
        }

        private void UpdateHitboxes()
        {
            playerHitbox.X = managerJeu.GetPlayerInput().GetPositionX();
            playerHitbox.Y = managerJeu.GetPlayerInput().GetPositionY();

            for (int i = 0; i < lasersHitbox.Count; i++)
            {
                RectangleF nouveauHitbox = lasersHitbox[i];
                nouveauHitbox.X = managerJeu.GetLasers()[i].GetLaserPositionX();
                nouveauHitbox.Y = managerJeu.GetLasers()[i].GetLaserPositionY();
                lasersHitbox[i] = nouveauHitbox;
            }

            for (int i = 0; i < ennemiesHitbox.Count; i++)
            {
                RectangleF nouveauHitbox = ennemiesHitbox[i];
                nouveauHitbox.X = managerJeu.GetEnemies()[i].GetAsteroidPositionX();
                nouveauHitbox.Y = managerJeu.GetEnemies()[i].GetAsteroidPositionY();
                ennemiesHitbox[i] = nouveauHitbox;
            }
        }

        private void GenerateEnemiesHitboxes()
        {
            ennemiesHitbox.Clear();
            for (int i = 0; i < managerJeu.GetEnemies().Count; i++)
            {
                RectangleF nouveauHitboxAsteroid = new RectangleF(0, 0, managerJeu.GetEnemies()[i].GetAsteroidWidth(), managerJeu.GetEnemies()[i].GetAsteroidHeight());
                nouveauHitboxAsteroid.Width = managerJeu.GetEnemies()[i].GetAsteroidWidth();
                nouveauHitboxAsteroid.Height = managerJeu.GetEnemies()[i].GetAsteroidHeight();
                ennemiesHitbox.Add(nouveauHitboxAsteroid);
            }
        }

        private void GenerateLasersHitboxes()
        {
            lasersHitbox.Clear();
            for (int i = 0; i < managerJeu.GetLasers().Count; i++)
            {
                RectangleF nouveauHitboxLaser = new RectangleF(50, 50, managerJeu.GetLasers()[i].GetLaserWidth(), managerJeu.GetLasers()[i].GetLaserHeight());
                nouveauHitboxLaser.Width = managerJeu.GetLasers()[i].GetLaserWidth();
                nouveauHitboxLaser.Height = managerJeu.GetLasers()[i].GetLaserHeight();
                lasersHitbox.Add(nouveauHitboxLaser);
            }
        }
    }
}
