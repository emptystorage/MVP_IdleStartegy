using Code.Core;
using Code.Core.Pools;
using Code.GameData;
using EmptyDI;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;

namespace Code.BattleParticipants
{
    [RequireComponent(typeof(Rigidbody2D), typeof(ParticipantAnimator))]
    public abstract class WarriorParticipant : BattleParticipant, ICombatable, IMovable
    {
        private WarriorParticipantPool _pool;
        private BattleParticipant _target;

        public Rigidbody2D Rigidbody { get; private set; }
        public ParticipantAnimator ParticipantAnimator { get; private set; }
        public int Damage { get; private set; }
        public float ReloadTime { get; private set; }
        public float HuntDistance { get; private set; }
        public float AttackDistance { get; private set; }
        public float Speed { get; private set; }
        public bool IsAttacking { get; private set; }

        [Inject]
        public void Construct(BattleInformation battleInformation, WarriorParticipantPool pool)
        {
            _pool = pool;
            base.Construct(battleInformation);
        }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            ParticipantAnimator = GetComponent<ParticipantAnimator>();
        }

        private void Update()
        {
            if (IsAttacking) return;

            Combat();
        }

        public abstract void Attack(in BattleParticipant target);

        public virtual void Combat()
        {
            if(TryGetTarget(out var targetInfo))
            {
                Debug.Log($"## owner - {transform.name} target - {targetInfo.target.name} - distance - {targetInfo.distance}");

                if(targetInfo.distance <= AttackDistance)
                {
                    //TEST
                    Attack(targetInfo.target);
                    Invoke(nameof(ReloadComplete), ReloadTime);
                    //NORMAL
                    //_target = targetInfo.target;
                    //ParticipantAnimator.PlayAnimation(ParticipantAnimationName.Attack);
                    //ParticipantAnimator.ExecutedAnimationEvent += OnAttackHandling;

                    IsAttacking = true;
                    Rigidbody.velocity = default;
                    Rigidbody.angularVelocity = default;

                    return;
                }

                if(targetInfo.distance <= HuntDistance)
                {
                    var direction = targetInfo.target.transform.position - transform.position;
                    Move(direction.normalized);
                }
                else
                {
                    var direction = Team == Team.Player ? Vector3.right : Vector3.left;
                    Move(direction);
                }
            }
        }

        public virtual void Move(Vector3 direction)
        {
            Rigidbody.velocity = direction * Speed;
        }

        protected void SetData(ComabatData data)
        {
            Damage = data.Damage;
            ReloadTime = data.ReloadTime;
            HuntDistance = data.HuntDistance;
            AttackDistance = data.AttackDistance;
            Speed = BattleInformation.ParticipantSpeed;

            base.SetData(data);
        }

        private bool TryGetTarget(out TargetInfo targetInfo)
        {
            targetInfo = default;

            var targetList = BattleInformation.GetUnitList(this, Team == Team.Player ? Team.Enemy : Team.Player);
            var minDistance = float.PositiveInfinity;
            var distance = float.PositiveInfinity;
            
            if(targetList != null)
            {
                foreach (var item in targetList)
                {
                    if (item.Equals(this)) continue;

                    distance = Vector3.Distance(transform.position, item.transform.position);

                    if(distance < minDistance)
                    {
                        minDistance = distance;

                        targetInfo.target = item;
                        targetInfo.distance = distance;
                    }
                }
            }

            return targetInfo.target != default;
        }

        private void OnAttackHandling()
        {
            Attack(_target);
            Invoke(nameof(ReloadComplete), ReloadTime);

            ParticipantAnimator.ExecutedAnimationEvent -= OnAttackHandling;
        }

        private void ReloadComplete()
        {
            IsAttacking = false;
        }

        private ref struct TargetInfo
        {
            public BattleParticipant target;
            public float distance;
        }
    }
}
