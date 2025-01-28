using System;
using Code.BattleParticipants.AttackLogic;

namespace Code.BattleParticipants
{
    public interface ICombatable
    {
        IAttackLogic AttackLogic { get; }
        int Damage { get; }
        float ReloadTime { get; }
        float HuntDistance { get; }
        float AttackDistance { get; }
    }
}
