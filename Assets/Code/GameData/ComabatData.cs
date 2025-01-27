using UnityEngine;

namespace Code.GameData
{
    [CreateAssetMenu(fileName = "New" + nameof(ComabatData), menuName = "GameDat/UnitBattleData/New" + nameof(ComabatData))]
    public class ComabatData : HealthBattleData
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _huntDistance;
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _reloadTime;

        public int Damage => _damage;
        public float HuntDistance => _huntDistance;
        public float AttackDistance => _attackDistance;
        public float ReloadTime => _reloadTime; 
    }
}