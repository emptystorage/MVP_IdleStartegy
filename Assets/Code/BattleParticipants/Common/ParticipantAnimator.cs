using System;
using UnityEngine;

namespace Code.BattleParticipant
{
    [RequireComponent(typeof(Animator))]
    public sealed class ParticipantAnimator : MonoBehaviour
    {
        private const string AnimationSpeedParameter = "Speed";

        private Animator _animator;

        public event Action ExecutedAnimationEvent;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayAnimation(string animationName, float offset, float animationSpeed = 1)
        {
            _animator.SetFloat(AnimationSpeedParameter, animationSpeed);
        }

        public void OnSendAnimationEvent(AnimationEvent animationEvent)
        {

        }
    }
}
