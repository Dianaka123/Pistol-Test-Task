using UnityEngine;

namespace Assets.Scripts.Configurations
{
    [CreateAssetMenu(fileName = "EnviromentConfiguration", menuName = "ScriptableObjects/EnviromentConfiguration")]
    public class EnviromentConfiguration : ScriptableObject
    {
        public GameObject LevelEnviroment;
    }
}