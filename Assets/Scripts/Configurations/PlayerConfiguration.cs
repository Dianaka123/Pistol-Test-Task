using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Configurations
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "ScriptableObjects/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        public float Speed;

        public Player Prefab;
    }
}