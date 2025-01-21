using UnityEngine;

namespace Code.BattleParticipant
{
    public sealed class BattleBase : BattleParticipant
    {
        [SerializeField] private Team _team;

        public override Team Team => _team;
    }
}
