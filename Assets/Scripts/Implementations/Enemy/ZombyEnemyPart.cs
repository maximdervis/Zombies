using Abstractions.Enemies;
using UnityEngine;

namespace Implementations.Enemy
{
    public class ZombyEnemyPart : EnemyPart
    {
        private void Start()
        {
            SetParentEnemy(GetComponentInParent<Abstractions.Enemies.Enemy>());
        }
    }
}
