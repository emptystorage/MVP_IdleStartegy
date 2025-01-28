using UnityEngine;
using Code.Core;
using Code.Core.StateMachine;

namespace Code.BattleParticipants.States
{
    public sealed class CombatState : State<WarriorParticipant>
    {
        public BattleInformation BattleInformation { get; set; }

        public override void Update()
        {
            if (TryGetTarget(out var targetInfo))
            {
                if (targetInfo.distance <= Owner.AttackDistance)
                {
                    var target = targetInfo.target;
                    Owner.StateMachine.ChangeState<AttackState>(state => state.Target = target);
                    return;
                }

                if (targetInfo.distance <= Owner.HuntDistance)
                {
                    var direction = targetInfo.target.transform.position - Owner.transform.position;
                    Owner.Rigidbody.velocity = direction * Owner.Speed;
                }
                else
                {
                    var direction = Owner.Team == Team.Player ? Vector3.right : Vector3.left;
                    Owner.Rigidbody.velocity = direction * Owner.Speed;
                }
            }
        }

        private bool TryGetTarget(out TargetInfo targetInfo)
        {
            targetInfo = default;

            var targetList = BattleInformation.GetUnitList(Owner, Owner.Team == Team.Player ? Team.Enemy : Team.Player);
            var minDistance = float.PositiveInfinity;
            var distance = float.PositiveInfinity;

            if (targetList != null)
            {
                foreach (var item in targetList)
                {
                    if (item.Equals(this)) continue;

                    distance = Vector3.Distance(Owner.transform.position, item.transform.position);

                    if (distance < minDistance)
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
