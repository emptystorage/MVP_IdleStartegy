using UnityEngine;
using Code.GameData;
using Code.Core.Command;

namespace Code.BattleParticipants
{
    public sealed class RangeWarrior : WarriorParticipant
    {
        [SerializeField] private RangeCombatData _data;

        public override void Setup()
        {
            base.SetData(_data);
        }

        public override void Attack(in BattleParticipant target)
        {
            var cmd = new CommandFactory<CreateProjectileCommand>().Create();
            cmd.Execute(this, target, _data.ProjectilePrefab);
        }
    }
}
