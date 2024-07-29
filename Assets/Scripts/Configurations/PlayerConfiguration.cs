using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Configurations
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "ScriptableObjects/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        public int Health;
        public float Speed;

        public Player Prefab;
    }
}