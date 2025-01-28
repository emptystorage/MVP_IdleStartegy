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
            Owner.ParticipantAnimator.ExecutedAnimationEvent += OnAttackAnimationEventHandling;
            Owner.ParticipantAnimator.PlayAnimation(ParticipantAnimationName.Attack);
        }

        public override void Exit()
        {
            Owner.ParticipantAnimator.ExecutedAnimationEvent -= OnAttackAnimationEventHandling;
        }

        private void OnAttackAnimationEventHandling()
        {
            Owner.AttackLogic.Execute(Owner, Target);
            Owner.ParticipantAnimator.ExecutedAnimationEvent -= OnAttackAnimationEventHandling;
            Owner.StateMachine.ChangeState<ReloadState>();
        }
    }
}
