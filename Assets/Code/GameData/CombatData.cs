using UnityEngine;

namespace Code.GameData
{
    [CreateAssetMenu(fileName = "New" + nameof(CombatData), menuName = "GameDat/UnitBattleData/New" + nameof(CombatData))]
    public class CombatData : HealthBattleData
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