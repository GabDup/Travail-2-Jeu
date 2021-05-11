using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Travail_2
{
    public class Enemies
    {
        private int asteroidSpeed;
        private int positionY;
        private int positionX;
        private int asteroidWidth;
        private int asteroidHeight;

        public Enemies(int PositionX, int AsteroidSpeed)
        {
            asteroidSpeed = AsteroidSpeed;
            positionY = -75;
            positionX = PositionX;
            asteroidWidth = 50;
            asteroidHeight = 75;
        }

        public int ChangerPositionY()
        {
            return positionY += asteroidSpeed;
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
