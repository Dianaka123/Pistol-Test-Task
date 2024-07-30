using Assets.Scripts.Models;
using System.Collections.Generic;

namespace Assets.Scripts.Systems.Enemies
{
    public interface IEnemyManager
    {
        IEnumerable<Enemy> GetEnemies();
    }
}
