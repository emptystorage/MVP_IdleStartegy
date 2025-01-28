using UnityEngine;
using Code.Core.StateMachine;

namespace Code.BattleParticipants.States
{
    public sealed class AttackState : State<WarriorParticipant>
    {
        public BattleParticipant Target { get; set; }        

        public override void Enter()
        {
            Owner.Rigidbody.velocity = default;
            Owner.Rigidbody.angularVelocity = default;
            Owner.ParticipantAnimator.ExecutedAnimationEvent += Hit;
            Owner.ParticipantAnimator.PlayAnimation(ParticipantAnimationName.Attack);
        }

        private void Hit()
        {
            Debug.Log("Bonk!");
            Owner.ParticipantAnimator.ExecutedAnimationEvent -= Hit;
            Owner.StateMachine.ChangeState<ReloadState>();
        }
    }
}
