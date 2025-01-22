using UnityEngine;

namespace Code.GameData
{
    [CreateAssetMenu(fileName = "New" + nameof(HealthBattleData), menuName = "GameDat/UnitBattleData/New" + nameof(HealthBattleData))]
    public class HealthBattleData : ScriptableObject
    {
        [SerializeField] private int _health;
        [SerializeField] private int _armor;

        public int Health => _health;
        public int Armor => _armor; 
    }
}