using Code.Core.Command;
using Code.Core.Pools;

namespace Code.BattleParticipants.AttackLogic
{
    public struct RangeAttackLogic : IAttackLogic
    {
        private readonly Projectile ProjectilePrefab;

        public RangeAttackLogic(Projectile projectilePrefab)
        {
            ProjectilePrefab = projectilePrefab;
        }

        public void Execute(in WarriorParticipant owner, in BattleParticipant target)
        {
            var cmd = new CommandConstructor<CreateProjectileCommand>().CreateCommand();
            cmd.Execute(owner, target, ProjectilePrefab);
        }
    }
}
