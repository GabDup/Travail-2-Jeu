using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Travail_2
{
    class Laser
    {
        
        bool isOffScreen;
        int lasertSpeed;
        int positionY;
        int positionX;
        int laserWidth;
        int laserHeight;
        Image Lazer = Image.FromFile("../../Images/laser_beam.png");
        Bitmap laserImage;
        public Laser()
        {
            isOffScreen = false;
            lasertSpeed = 5;
            positionY = 0;
            positionX = 0;
            laserWidth = 50;
            laserHeight = 75;
            laserImage = new Bitmap(Lazer, laserWidth, laserHeight);

        }
        //fonction pour changer la positionY par rapport a la vitesse et regarder si il est en dehors de l'ecran, si oui, effacer dans la form
        public int ChangerPositionY()
        {
            return positionY = positionY + lasertSpeed;
        }
        public Bitmap GetAsteroidImage()
        {
            return laserImage;
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
            return lasertSpeed;
        }
    }
}
}
