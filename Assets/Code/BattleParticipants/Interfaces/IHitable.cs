using System;

namespace Code.BattleParticipant
{
    public interface IHitable
    {
        int MaxHealth { get; }
        int CurrentHealth { get; }

        event Action<int, int> ChangeHealth;
        event Action Dead;

        void Hit(int damage);
    }
}
