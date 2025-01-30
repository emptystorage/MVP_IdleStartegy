using Code.BattleParticipants;
using UnityEngine;
using System.Collections;
using EmptyDI;

namespace Code.Core.Pools
{
    public sealed class Projectile : MonoBehaviour
    {
        private ProjectilePool _pool;
        [SerializeField] private float _speed;

        [Inject]
        public void Construct(ProjectilePool pool)
        {
            _pool = pool;
        }

        public void Shoot(BattleParticipant target, int damage)
        {
            StartCoroutine(Fly(target, damage));
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator Fly(BattleParticipant target, int damage)
        {
            var distance = float.PositiveInfinity;

            while (distance > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);
                distance = Vector3.Distance(target.transform.position, transform.position);
                yield return null;
            }

            target.Hit(damage);
            _pool.Despawn(this);
        }
    }
}
