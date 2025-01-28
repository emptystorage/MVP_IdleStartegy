using UnityEngine;
using Code.GameData;

namespace Code.BattleParticipants
{
    public sealed class MeleeWarrior : WarriorParticipant
    {
        [SerializeField] private ComabatData _data;

        public override void Setup()
        {
            base.SetData(_data);
        }
    }
}
