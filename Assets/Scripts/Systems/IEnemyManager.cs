using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Systems
{
    public interface IEnemyManager
    {
        IEnumerable<Enemy> GetEnemies();
    }
}
