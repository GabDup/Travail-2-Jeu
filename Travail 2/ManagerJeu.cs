using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_2
{
    public class ManagerJeu
    {
        private PlayerInput playerInput;
        private List<Enemies> enemies;
        private List<Laser> lasers;
        private int mapWidth;
        private int mapHeight;
        private int score;
        private int difficulte;
        private int fireDelay;

        public ManagerJeu(int MapWidth, int MapHeight)
        {
            playerInput = new PlayerInput();
            enemies = new List<Enemies>();
            lasers = new List<Laser>();
            mapWidth = MapWidth;
            mapHeight = MapHeight;
            score = 0;
            difficulte = 1;
            fireDelay = 15;
        }

        public int GetMapWidth()
        {
            return mapWidth;
        }

        public int GetMapHeight()
        {
            return mapHeight;
        }

        public List <Enemies> GetEnemies()
        {
            return enemies;
        }

        public List<Laser> GetLasers()
        {
            return lasers;
        }

        public PlayerInput GetPlayerInput()
        {            
            return playerInput;
        }

        public int GetScore()
        {
            return score;
        }

        public void SetScore(int Score)
        {
            score = Score;
        }

        public void AddPoints()
        {
            score += 50;
        }

        public int GetDifficulte()
        {
            return difficulte;
        }

        public void SetDifficulte(int Difficulte)
        {
            difficulte = Difficulte;
        }

        public void ResetPlayerInput()
        {
            GetPlayerInput().SetGoLeft(false);
            GetPlayerInput().SetGoDown(false);
            GetPlayerInput().SetGoRight(false);
            GetPlayerInput().SetGoUp(false);
        }

        public void Fire()
        {
            if (fireDelay <= 0)
            {
                Laser newLaser = new Laser(GetPlayerInput().GetPositionX()+20,GetPlayerInput().GetPositionY()-30);
                GetLasers().Add(newLaser);
                fireDelay = 15;
            }
        }

        public void DecreaseFireDelay()
        {
            if (fireDelay > 0)
            {
                fireDelay--;
            }
        }
    }
}
