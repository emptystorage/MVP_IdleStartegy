using UnityEngine;
using Code.Core.StateMachine;

namespace Code.BattleParticipants.States
{
    public sealed class ReloadState : State<WarriorParticipant>
    {
        private float _time;

        public override void Enter()
        {
            _time = Time.time + Owner.ReloadTime;
        }

        public override void Update()
        {
            if(Time.time >= _time)
            {
                Owner.StateMachine.ChangeState<CombatState>();
            }
        }
    }
}
