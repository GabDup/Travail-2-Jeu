using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_2
{
    class PlayerInput
    {
        bool goLeft;
        bool goRight;
        bool goUp;
        bool goDown;
        bool laser;

        public PlayerInput()
        {
            goLeft = false;
            goRight = false;
            goUp = false;
            goDown = false;
        }

        public bool GetGoLeft()
        {
            return goLeft;
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

        public bool GetGoUp()
        {
            return goUp;
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
    }
}
