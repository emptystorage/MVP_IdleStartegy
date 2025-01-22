using UnityEngine;
using Code.BattleParticipants;

namespace Code.GameData
{
    [CreateAssetMenu(fileName = "New" + nameof(PlayerWarriorButtonData), menuName = "GameDat/Create/New" + nameof(PlayerWarriorButtonData))]
    public sealed class PlayerWarriorButtonData : ScriptableObject
    {
        [SerializeField] private WarriorParticipant _prefab;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _cost;
        
        public WarriorParticipant Prefab => _prefab;
        public Sprite Icon => _icon;
        public int Cost => _cost;
    }
}