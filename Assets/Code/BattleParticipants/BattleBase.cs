using Code.GameData;
using UnityEngine;

namespace Code.BattleParticipants
{
    public sealed class BattleBase : BattleParticipant
    {
        [SerializeField] private HealthBattleData _data;

        public override void Setup()
        {
            base.SetData(_data);
        }
    }
}
