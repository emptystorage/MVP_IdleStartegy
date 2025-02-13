﻿using System;

namespace Code.BattleParticipants
{
    public interface IHitable
    {
        int MaxHealth { get; }
        int CurrentHealth { get; }
        int Armor { get; }

        event Action<int, int> ChangeHealth;
        event Action<IHitable> Dead;

        void Hit(int damage);
    }
}
