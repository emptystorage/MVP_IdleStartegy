using System;
using Code.Core.Pools;
using Code.BattleParticipants;

namespace Code.Core.Command
{
    public sealed class StartBattleCommand : ICommand, IDisposable
    {
        private readonly BattleBasePool Pool;
        private readonly BattleSceneContext Context;

        public StartBattleCommand(BattleBasePool pool, BattleSceneContext context)
        {
            Pool = pool;
            Context = context;
        }

        public void Execute(in BattleBase playerBasePrefab, in BattleBase enemyBasePrefab)
        {
            Pool.Spawn(playerBasePrefab).transform.position = Context.PlayerBaseSpawnPoint;
            Pool.Spawn(enemyBasePrefab).transform.position = Context.EnemyBaseSpawnPoint;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
