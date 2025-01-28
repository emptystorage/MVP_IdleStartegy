using Code.Core.Pools;
using UnityEngine;

namespace Code.GameData
{
    [CreateAssetMenu(fileName = "New" + nameof(RangeCombatData), menuName = "GameDat/UnitBattleData/New" + nameof(RangeCombatData))]
    public class RangeCombatData : CombatData
    {
        [SerializeField] private Projectile _projectilePrefab;

        public Projectile ProjectilePrefab => _projectilePrefab;
    }
}