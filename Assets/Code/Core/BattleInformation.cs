using System;
using System.Collections.Generic;
using Code.Core.Common;
using Code.BattleParticipant;

namespace Code.Core
{
    public sealed class BattleInformation : IDisposable
    {
        private readonly Dictionary<Team, LinkedList<BattleParticipant.BattleParticipant>> UnitInBattle;

        public BattleInformation(int startResourcesCount)
        {
            UnitInBattle = new Dictionary<Team, LinkedList<BattleParticipant.BattleParticipant>>();

            ResourcesValue = new ReactValue<int>(startResourcesCount);
            EnemyUnitCount = new ReactValue<int>();
            PlayerUnitCount = new ReactValue<int>();
        }

        public ReactValue<int> ResourcesValue { get; }
        public ReactValue<int> EnemyUnitCount { get; }
        public ReactValue<int> PlayerUnitCount { get; }

        public void AddUnit(in BattleParticipant.BattleParticipant unit)
        {
            if(!UnitInBattle.TryGetValue(unit.Team, out var list))
            {
                list = new();
                UnitInBattle.Add(unit.Team, list);
            }

            list.AddFirst(unit);
            ChangeUnitCount(unit.Team, 1);
        }

        public IReadOnlyCollection<BattleParticipant.BattleParticipant> GetUnitList(in BattleParticipant.BattleParticipant unit)
        {
            UnitInBattle.TryGetValue(unit.Team, out var list);
            return list;
        }

        public void RemoveUnit(in BattleParticipant.BattleParticipant unit)
        {
            if(UnitInBattle.TryGetValue(unit.Team, out var list))
            {
                list.Remove(unit);
                ChangeUnitCount(unit.Team, -1);
            }
        }

        public void Dispose()
        {
            UnitInBattle.Clear();

            ResourcesValue.Dispose();
            EnemyUnitCount.Dispose();
            PlayerUnitCount.Dispose();

            GC.SuppressFinalize(this);
        }

        private void ChangeUnitCount(Team team, int delta)
        {
            switch (team)
            {
                case Team.Player:
                    PlayerUnitCount.Value += delta;
                    break;
                case Team.Enemy:
                    EnemyUnitCount.Value += delta;
                    break;
            }
        }
    }
}