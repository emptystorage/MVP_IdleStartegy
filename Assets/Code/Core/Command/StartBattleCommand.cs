using System;
using Code.Core.Pools;
using Code.BattleParticipants;
using Code.Core.Common;

namespace Code.Core.Command
{
    public sealed class StartBattleCommand : ICommand, IDisposable
    {
        private readonly EnemyWaveSpawner EnemyWaveSpawner;
        private readonly BattleBasePool Pool;
        private readonly BattleSceneContext Context;

        public StartBattleCommand(EnemyWaveSpawner enemyWaveSpawner, BattleBasePool pool, BattleSceneContext context)
        {
            EnemyWaveSpawner = enemyWaveSpawner;
            Pool = pool;
            Context = context;
        }

        public void Execute(in BattleBase playerBasePrefab, in BattleBase enemyBasePrefab)
        {
            Pool.Spawn(playerBasePrefab).transform.position = Context.PlayerBaseSpawnPoint;
            Pool.Spawn(enemyBasePrefab).transform.position = Context.EnemyBaseSpawnPoint;
            EnemyWaveSpawner.StartBattle();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
