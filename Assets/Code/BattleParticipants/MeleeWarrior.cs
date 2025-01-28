﻿using UnityEngine;
using Code.GameData;
using Code.BattleParticipants.AttackLogic;

namespace Code.BattleParticipants
{

    public sealed class MeleeWarrior : WarriorParticipant
    {
        [SerializeField] private CombatData _data;

        public override IAttackLogic AttackLogic => new MeleeAttacklLogic();

        public override void Setup()
        {
            base.SetData(_data);
        }
    }
}
