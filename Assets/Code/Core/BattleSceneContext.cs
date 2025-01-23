using System;
using UnityEngine;

namespace Code.Core
{
    [Serializable]
    public sealed class BattleSceneContext : IDisposable
    {
        [SerializeField] private Transform _playerBaseSpawnPoint;
        [SerializeField] private Transform _enemyBaseSpawnPoint;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Transform _enemySpawnPoint;

        public Vector3 PlayerBaseSpawnPoint => _playerBaseSpawnPoint.position;
        public Vector3 EnemyBaseSpawnPoint => _enemyBaseSpawnPoint.position;
        public Vector3 PlayerSpawnPoint => _playerSpawnPoint.position;
        public Vector3 EnemySpawnPoint => _enemySpawnPoint.position;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}