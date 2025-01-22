using Code.Core;
using Code.Core.Pools;
using Code.GameData;
using EmptyDI;
using UnityEngine;

namespace Code.BattleParticipants
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class WarriorParticipant : BattleParticipant, ICombatable, IMovable
    {
        private WarriorParticipantPool _pool;
        public Rigidbody2D Rigidbody { get; private set; }
        public int Damage { get; private set; }
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
                if(targetInfo.distance <= AttackDistance)
                {
                    Attack(targetInfo.target);
                    IsAttacking = true;
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
            HuntDistance = data.HuntDistance;
            AttackDistance = data.AttackDistance;
            Speed = data.Speed;

            base.SetData(data);
        }

        private bool TryGetTarget(out TargetInfo targetInfo)
        {
            targetInfo = default;

            var targetList = BattleInformation.GetUnitList(this);
            var minDistance = float.PositiveInfinity;
            var distance = float.PositiveInfinity;
            
            if(targetList != null)
            {
                foreach (var item in targetList)
                {
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


        private ref struct TargetInfo
        {
            public BattleParticipant target;
            public float distance;
        }
    }
}
