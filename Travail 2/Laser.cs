using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Travail_2
{
    public class Laser
    {
        private int laserSpeed;
        private int laserWidth;
        private int laserHeight;
        private int positionY;
        private int positionX;

        public Laser(int PositionX, int PositionY)
        {
            laserSpeed = 10;
            laserWidth = 50;
            laserHeight = 75;
            positionY = PositionY;
            positionX = PositionX;
        }

        public int ChangerPositionY()
        {
            return positionY -= laserSpeed;
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
            return laserSpeed;
        }

        public int GetLaserHeight()
        {
            return laserHeight;
        }

        public int GetLaserWidth()
        {
            return laserWidth;
        }

        public int GetLaserPositionX()
        {
            return positionX;
        }

        public int GetLaserPositionY()
        {
            return positionY;
        }

        public int GetPositionX()
        {
            return positionX;
        }

        public int GetPositionY()
        {
            return positionY;
        }
    }
}
