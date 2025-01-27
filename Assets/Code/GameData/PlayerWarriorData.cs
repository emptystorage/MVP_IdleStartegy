using UnityEngine;
using Code.BattleParticipants;

namespace Code.GameData
{
    [CreateAssetMenu(fileName = "New" + nameof(PlayerWarriorData), menuName = "GameDat/Create/New" + nameof(PlayerWarriorData))]
    public sealed class PlayerWarriorData : ScriptableObject
    {
        [SerializeField] private WarriorParticipant _prefab;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _cost;
        
        public WarriorParticipant Prefab => _prefab;
        public Sprite Icon => _icon;
        public int Cost => _cost;
    }
}