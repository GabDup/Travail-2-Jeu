﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Travail_2
{
    class Laser
    {        
        int laserSpeed;
        int laserWidth;
        int laserHeight;
        PlayerInput player;
        int positionY;
        int positionX;

        public Laser()
        {
            laserSpeed = 5;
            laserWidth = 50;
            laserHeight = 75;
            player = new PlayerInput();
            positionY = player.GetPositionY();
            positionX = player.GetPositionX();
        }

        public int ChangerPositionY()
        {
            return positionY = positionY + laserSpeed;
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

        public void Fire()
        {

        }
    }
}