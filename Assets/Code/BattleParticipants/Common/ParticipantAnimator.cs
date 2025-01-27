using System;
using UnityEngine;

namespace Code.BattleParticipants
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

        private void OnDestroy()
        {
            ExecutedAnimationEvent = null;
        }

        public void PlayAnimation(string animationName, float offset = 0.1f, float animationSpeed = 1)
        {
            _animator.SetFloat(AnimationSpeedParameter, animationSpeed);
            _animator.CrossFade(animationName, offset);
        }

        public void OnSendAnimationEvent(AnimationEvent animationEvent)
        {
            ExecutedAnimationEvent?.Invoke();
        }
    }
}
