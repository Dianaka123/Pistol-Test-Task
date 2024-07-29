using Assets.Scripts.Models;
using System.Collections.Generic;

namespace Assets.Scripts.Managers
{
    public class GameManager
    {
        public Player Player { get; set; }
        public Enemy[] Enemies { get; set; }

        public List<Weapon> Weapons { get; set; }
    }
}
