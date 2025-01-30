using System;
using UnityEngine;
using Code.BattleParticipants;
using Code.Core.Pools;

using Random = UnityEngine.Random;
using Code.GUI;

namespace Code.Core.Command
{
    public sealed class CreateWarriorCommand : ICommand
    {
        private const float CreatePointOffset = 2;

        private readonly BattleSceneContext BattleSceneContex;
        private readonly GUISceneContext GUISceneContext;
        private readonly WarriorParticipantPool WarriorPool;
        private readonly UnitBattleInfoElementPool UIElementPool;

        public CreateWarriorCommand(BattleSceneContext battleSceneContex, GUISceneContext guiSceneContext, WarriorParticipantPool warriorPool, UnitBattleInfoElementPool uiElementPool)
        {
            BattleSceneContex = battleSceneContex;
            GUISceneContext = guiSceneContext;
            WarriorPool = warriorPool;
            UIElementPool = uiElementPool;
        }

        public void Execute(in WarriorParticipant prefab)
        {
            var point = prefab.Team == Team.Player 
                                ? BattleSceneContex.PlayerSpawnPoint 
                                : BattleSceneContex.EnemySpawnPoint;

            point += (Vector3)Random.insideUnitCircle * CreatePointOffset;

            var warrior = WarriorPool.Spawn(prefab);
            warrior.transform.position = point;
            warrior.Dead += OnDead;

            //GUI
            var uiElement = UIElementPool.Spawn(GUISceneContext.UnitBattleInfoElementRoot);
            uiElement.Setup(warrior);
        }

        private void OnDead(IHitable participant)
        {
            participant.Dead -= OnDead;
            WarriorPool.Despawn(participant as WarriorParticipant);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
