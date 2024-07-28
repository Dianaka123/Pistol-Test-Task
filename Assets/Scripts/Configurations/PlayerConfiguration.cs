using Assets.Scripts.Models;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Configurations
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "ScriptableObjects/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        public int Health;
        public int Speed;
        public int JumpHeight;

        public Player PlayerPrefab;
    }
}