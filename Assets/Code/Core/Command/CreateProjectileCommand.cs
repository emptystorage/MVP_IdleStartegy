using Code.BattleParticipants;
using Code.Core.Pools;
using System;

namespace Code.Core.Command
{
    public sealed class CreateProjectileCommand : ICommand
    {
        private readonly ProjectilePool Pool;

        public CreateProjectileCommand(ProjectilePool pool)
        {
            Pool = pool;
        }

        public void Execute(in WarriorParticipant owner, in BattleParticipant target, in Projectile prefab)
        {
            var projectile = Pool.Spawn(prefab);
            projectile.transform.position = owner.transform.position;
            projectile.Shoot(target);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
