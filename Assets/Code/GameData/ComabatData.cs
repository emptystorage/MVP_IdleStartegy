using UnityEngine;

namespace Code.GameData
{
    [CreateAssetMenu(fileName = "New" + nameof(ComabatData), menuName = "GameDat/UnitBattleData/New" + nameof(ComabatData))]
    public class ComabatData : HealthBattleData
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _huntDistance;
        [SerializeField] private float _attackDistance;

        public int Damage => _damage;
        public float Speed => _speed;
        public float HuntDistance => _huntDistance;
        public float AttackDistance => _attackDistance;
    }
}