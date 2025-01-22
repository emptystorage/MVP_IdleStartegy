using System;
using UnityEngine;

namespace Code.Core
{
    public sealed class BattleSceneContex : IDisposable
    {
        public BattleSceneContex(Transform playerSpawnPoint, Transform enemySpawnPoint)
        {
            PlayerSpawnPoint = playerSpawnPoint;
            EnemySpawnPoint = enemySpawnPoint;
        }

        public Transform PlayerSpawnPoint { get; }
        public Transform EnemySpawnPoint { get; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}