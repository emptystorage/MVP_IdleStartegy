using UnityEngine;
using Code.GameData;

namespace Code.BattleParticipants
{

    public sealed class MeleeWarrior : WarriorParticipant
    {
        [SerializeField] private CombatData _data;

        public override void Setup()
        {
            base.SetData(_data);
        }

        public override void Attack(in BattleParticipant target)
        {
            target.Hit(Damage);
        }
    }
}
