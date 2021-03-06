using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_2
{
    public class PlayerInput
    {
        private bool goLeft;
        private bool goRight;
        private bool goUp;
        private bool goDown;
        private int playerPositionX;
        private int playerPositionY;
        private int playerSpeed;
        private int playerWidth;
        private int playerHeight;

        public PlayerInput()
        {
            goLeft = false;
            goRight = false;
            goUp = false;
            goDown = false;
            playerPositionX = 0;
            playerPositionY = 0;
            playerSpeed = 20;
            playerWidth = 90;
            playerHeight = 130;
        }

        public bool GetGoLeft()
        {
            return goLeft;
        }

        public int GetPositionY()
        {
            return playerPositionY;
        }

        public int GetPositionX()
        {
            return playerPositionX;
        }

        public void SetGoLeft(bool goleft)
        {
            goLeft = goleft;
        }

        public bool GetGoRight()
        {
            return goRight;
        }

        public void SetGoRight(bool goright)
        {
            goRight = goright;
        }

        public int GetPlayerWidth()
        {
            return playerWidth;
        }

        public void SetPositionX(int positionX)
        {
            playerPositionX = positionX;
        }

        public void SetPositionY(int positionY)
        {
            playerPositionY = positionY;
        }

        public bool GetGoUp()
        {
            return goUp;
        }

        public int GetPlayerHeight()
        {
            return playerHeight;
        }

        public void SetGoUp(bool goup)
        {
            goUp = goup;
        }

        public bool GetGoDown()
        {
            return goDown;
        }

        public void SetGoDown(bool godown)
        {
            goDown = godown;
        }

        public int GetPlayerSpeed()
        {
            return playerSpeed;
        }
    }
}
