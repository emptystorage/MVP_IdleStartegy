using UnityEngine;
using EmptyDI;
using Code.Core;
using Code.Core.Pools;
using Code.GameData;
using Code.Core.StateMachine;
using Code.BattleParticipants.States;

namespace Code.BattleParticipants
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class WarriorParticipant : BattleParticipant, ICombatable, IMovable, IStateMachineOwner<WarriorParticipant>
    {
        private WarriorParticipantPool _pool;
        [SerializeField] private ParticipantAnimator _participantAnimator;

        public Rigidbody2D Rigidbody { get; private set; }
        public ParticipantAnimator ParticipantAnimator => _participantAnimator;
        public StateMachine<WarriorParticipant> StateMachine { get; private set; } 
        public int Damage { get; private set; }
        public float ReloadTime { get; private set; }
        public float HuntDistance { get; private set; }
        public float AttackDistance { get; private set; }
        public float Speed { get; private set; }

        [Inject]
        public void Construct(BattleInformation battleInformation, WarriorParticipantPool pool)
        {
            _pool = pool;

            Rigidbody = GetComponent<Rigidbody2D>();
            StateMachine = new StateMachine<WarriorParticipant>(this);
            StateMachine.ChangeState<MeleeCombatState>(state => state.BattleInformation = battleInformation);

            base.Construct(battleInformation);
        }

        protected override void OnDestroy()
        {
            StateMachine.Dispose();
            StateMachine = null;

            base.OnDestroy();
        }

        private void Reset() => OnValidate();

        private void OnValidate()
        {
            var animator = GetComponentInChildren<Animator>();

            if (!animator.TryGetComponent<ParticipantAnimator>(out _participantAnimator))
            {
                _participantAnimator = animator.gameObject.AddComponent<ParticipantAnimator>();
            }
        }

        private void Update() => StateMachine.Update();

        protected void SetData(ComabatData data)
        {
            Damage = data.Damage;
            ReloadTime = data.ReloadTime;
            HuntDistance = data.HuntDistance;
            AttackDistance = data.AttackDistance;
            Speed = BattleInformation.ParticipantSpeed;

            base.SetData(data);
        }
    }
}
