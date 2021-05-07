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
        int asteroidSpeed;
        int positionY;
        int positionX;
        int asteroidWidth;
        int asteroidHeight;

        public Enemies()
        {
            asteroidSpeed = 5;
            positionY = 0;
            positionX = random.Next(50, 1400);
            asteroidWidth = 50;
            asteroidHeight = 75;
        }

        //fonction pour changer la positionY par rapport a la vitesse et regarder si il est en dehors de l'ecran, si oui, effacer dans la form
        public int ChangerPositionY()
        {
            return positionY -= positionY + asteroidSpeed;
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
        public int GetAsteroidHeight()
        {
            return asteroidHeight;
        }

        public int GetAsteroidWidth()
        {
            return asteroidWidth;
        }
    }
}
