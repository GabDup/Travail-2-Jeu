using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travail_2
{
    class ManagerJeu
    {
        PlayerInput playerInput;
        List<Enemies> enemies;
        Laser laser;
        int mapWidth;
        int mapHeight;

        public ManagerJeu(int MapWidth, int MapHeight)
        {
            playerInput = new PlayerInput();
            enemies = new List<Enemies>();
            laser = new Laser();
            mapWidth = MapWidth;
            mapHeight = MapHeight;
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
    }
}
