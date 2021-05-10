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
        private Laser laser;
        private int mapWidth;
        private int mapHeight;
        private int score;
        private int difficulte;

        public ManagerJeu(int MapWidth, int MapHeight)
        {
            playerInput = new PlayerInput();
            enemies = new List<Enemies>();
            laser = new Laser();
            mapWidth = MapWidth;
            mapHeight = MapHeight;
            score = 0;
            difficulte = 1;
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

        public Laser GetLaser()
        {
            return laser;
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
            score += Score;
        }

        public int GetDifficulte()
        {
            return difficulte;
        }

        public void SetDifficulte(int Difficulte)
        {
            difficulte = Difficulte;
        }
    }
}
