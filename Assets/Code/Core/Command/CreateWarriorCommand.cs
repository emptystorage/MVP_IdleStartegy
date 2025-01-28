﻿using System;
using UnityEngine;
using Code.BattleParticipants;
using Code.Core.Pools;

using Random = UnityEngine.Random;

namespace Code.Core.Command
{
    public sealed class CreateWarriorCommand : ICommand
    {
        private const float CreatePointOffset = 2;

        private readonly BattleSceneContext BattleSceneContex;
        private readonly WarriorParticipantPool Pool;

        public CreateWarriorCommand(BattleSceneContext battleSceneContex, WarriorParticipantPool pool)
        {
            BattleSceneContex = battleSceneContex;
            Pool = pool;
        }

        public void Execute(in WarriorParticipant prefab)
        {
            var point = prefab.Team == Team.Player 
                                ? BattleSceneContex.PlayerSpawnPoint 
                                : BattleSceneContex.EnemySpawnPoint;

            point += (Vector3)Random.insideUnitCircle * CreatePointOffset;

            var warrior = Pool.Spawn(prefab);
            warrior.transform.position = point;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
