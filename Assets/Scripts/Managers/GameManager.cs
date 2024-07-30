using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager
    {
        public GameObject Enviroment;
        public Player Player { get; set; }
        public Enemy[] Enemies { get; set; }

    }
}
