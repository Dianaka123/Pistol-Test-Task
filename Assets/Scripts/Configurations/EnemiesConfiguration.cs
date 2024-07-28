using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Configurations
{
    [CreateAssetMenu(fileName = "EnemiesConfiguration", menuName = "ScriptableObjects/EnemiesConfiguration")]
    public class EnemiesConfiguration : ScriptableObject
    {
        [Serializable]
        public class EnemyConfig
        {
            public Enemy Prefab;
            public int Health;
            public bool isCanBeDestroyed;
        }

        public List<EnemyConfig> Enemies = new ();
    }
}