using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Travail_2
{
    class Enemies
    {
        Random random = new Random();
        bool isOffScreen;
        int asteroidSpeed;
        int positionY;
        int positionX;
        int asteroidWidth;
        int asteroidHeight;
        Image Asteroid = Image.FromFile("../../Images/Asteroid.png");
        Bitmap asteroidImage;
        public Enemies()
        {
            isOffScreen = false;
            asteroidSpeed = 5;
            positionY = 0;
            positionX = random.Next(50, 1230);
            asteroidWidth = 50;
            asteroidHeight = 75;
            asteroidImage = new Bitmap(Asteroid, asteroidWidth, asteroidHeight);

        }
        //fonction pour changer la positionY par rapport a la vitesse et regarder si il est en dehors de l'ecran, si oui, effacer dans la form
        public int ChangerPositionY()
        {
            return positionY = positionY + asteroidSpeed;
        }
        public void SetIsOffScreen(bool isoffscreen)
        {
            isOffScreen = isoffscreen;
        }
        public Bitmap GetAsteroidImage()
        {
            return asteroidImage;
        }
        public int GetAsteroidPositionY()
        {
            return positionY;
        }
        public int GetAsteroidPositionX()
        {
            return positionX;
        }
        public int GetAsteroidSpeed()
        {
            return asteroidSpeed;
        }
    }
}
