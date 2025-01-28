using UnityEngine;
using Code.GameData;
using Code.BattleParticipants.AttackLogic;

namespace Code.BattleParticipants
{
    public sealed class RangeWarrior : WarriorParticipant
    {
        [SerializeField] private RangeCombatData _data;

        public override IAttackLogic AttackLogic => new RangeAttackLogic(_data.ProjectilePrefab);

        public override void Setup()
        {
            base.SetData(_data);
        }
    }
}
