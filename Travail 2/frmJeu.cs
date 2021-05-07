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
        PlayerInput playerInput;
        List<Enemies> CurrentEnemies = new List<Enemies>();
        Bitmap backgroundImage;
        Bitmap spaceshipImage;
        Bitmap gameImage;
        int playerPositionX = 0;
        int playerPositionY = 0;
        int mapWidth = 1280;
        int mapHeight = 720;
        int spaceshipWidth = 90;
        int spaceshipHeight = 130;
        int laserWidth = 50;
        int laserHeight = 90;
        int playerSpeed = 10;
        int compteur = 0;

        public frmJeu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image background = Image.FromFile("../../Images/bg_space_seamless_1.png");
            Image spaceship = Image.FromFile("../../Images/flashtestship.png");

            backgroundImage = new Bitmap(background, mapWidth, mapHeight);
            spaceshipImage = new Bitmap(spaceship, spaceshipWidth, spaceshipHeight);
            gameImage = new Bitmap(mapWidth, mapHeight);

            playerPositionX = mapWidth / 2 - spaceshipWidth / 2;
            playerPositionY = mapHeight / 2 - spaceshipHeight / 2;

            Width = mapWidth;
            Height = mapHeight;

            playerInput = new PlayerInput();

            CreateEnemies();

            GameTimer.Start();
        }
        private void CreateEnemies()
        {
            for (int i = 0; i <= 5; i++)
            {
                CurrentEnemies.Add(new Enemies());
            }
        }

        //fonction pour deplacement asteroid et effacer si offscreen=true
        //fonction pour deplacement laser et effacer si offscreen=true
        private void EnemiesMouvement()
        {
            for (int i = 0; i < CurrentEnemies.Count; i++)
            {
                foreach (Enemies enemies in CurrentEnemies)
                {
                    enemies.ChangerPositionY();
                }
                if (CurrentEnemies[i].GetAsteroidPositionY() > 720)
                {
                    CurrentEnemies[i].SetIsOffScreen(true);
                    CurrentEnemies[i].GetAsteroidImage().Dispose();
                    CurrentEnemies.Remove(CurrentEnemies[i]);
                }
            }
        }
        private void Draw()
        {
            gameImage.Dispose();
            gameImage = new Bitmap(mapWidth, mapHeight);

            using (Graphics graphics = Graphics.FromImage(gameImage))
            {
                graphics.DrawImage(backgroundImage, 0, 0);
                graphics.DrawImage(spaceshipImage, playerPositionX, playerPositionY);
                foreach (Enemies enemies in CurrentEnemies)
                {
                    graphics.DrawImage(enemies.GetAsteroidImage(), enemies.GetAsteroidPositionX(), enemies.GetAsteroidPositionY());
                }

                //afficher plusieurs asteroids (foreach)
            }

            this.BackgroundImage = gameImage;

        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (playerInput.GetGoLeft())
            {
                if (playerPositionX > 10)
                {
                    playerPositionX = playerPositionX - playerSpeed;
                }
            }
            else if (playerInput.GetGoRight())
            {
                if (playerPositionX < 1280 - spaceshipWidth)
                {
                    playerPositionX = playerPositionX + playerSpeed;
                }
            }
            if (playerInput.GetGoUp())
            {
                if (playerPositionY > 10)
                {
                    playerPositionY = playerPositionY - playerSpeed;
                }
            }
            else if (playerInput.GetGoDown())
            {
                if (playerPositionY < 720 - spaceshipHeight)
                {
                    playerPositionY = playerPositionY + playerSpeed;
                }
            }
            compteur++;
            if (compteur >= 10)
            {
                CurrentEnemies.Add(new Enemies());
                compteur = 0;
            }

            EnemiesMouvement();

            Draw();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerInput.SetGoLeft(true);
            }
            else if (e.KeyCode == Keys.Right)
            {
                playerInput.SetGoRight(true);
            }
            else if (e.KeyCode == Keys.Up)
            {
                playerInput.SetGoUp(true);
            }
            else if (e.KeyCode == Keys.Down)
            {
                playerInput.SetGoDown(true);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerInput.SetGoLeft(false);
            }
            else if (e.KeyCode == Keys.Right)
            {
                playerInput.SetGoRight(false);
            }
            else if (e.KeyCode == Keys.Up)
            {
                playerInput.SetGoUp(false);
            }
            else if (e.KeyCode == Keys.Down)
            {
                playerInput.SetGoDown(false);
            }
        }
    }
}
