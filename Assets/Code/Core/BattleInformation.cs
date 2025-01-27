using System;
using System.Collections.Generic;
using Code.Core.Common;
using Code.BattleParticipants;
using Code.Core.Pools;

namespace Code.Core
{
    public sealed class BattleInformation : IDisposable
    {
        private readonly Dictionary<Team, LinkedList<BattleParticipant>> UnitInBattle;

        public BattleInformation(int startResourcesCount, float participantSpeed)
        {
            UnitInBattle = new Dictionary<Team, LinkedList<BattleParticipant>>();

            ResourcesValue = new ReactValue<int>(startResourcesCount);
            EnemyUnitCount = new ReactValue<int>();
            PlayerUnitCount = new ReactValue<int>();
            ParticipantSpeed = participantSpeed;
        }

        public ReactValue<int> ResourcesValue { get; }
        public ReactValue<int> EnemyUnitCount { get; }
        public ReactValue<int> PlayerUnitCount { get; }
        public float ParticipantSpeed { get; }

        public void AddUnit(in BattleParticipant unit)
        {
            if(!UnitInBattle.TryGetValue(unit.Team, out var list))
            {
                list = new();
                UnitInBattle.Add(unit.Team, list);
            }

            list.AddFirst(unit);
            ChangeUnitCount(unit.Team, 1);
        }

        public IReadOnlyCollection<BattleParticipant> GetUnitList(in BattleParticipant unit, Team team)
        {
            UnitInBattle.TryGetValue(team, out var list);
            return list;
        }

        public void RemoveUnit(in BattleParticipant unit)
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