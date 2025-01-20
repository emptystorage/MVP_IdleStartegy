using System.Collections;
using UnityEngine;

namespace Code.GameData
{
    [CreateAssetMenu(fileName = "New" + nameof(UnitData), menuName = "GameDat/Create/New" + nameof(UnitData))]
    public sealed class UnitData : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _cost;
        //TODO add unit prefab

        public Sprite Icon => _icon;
        public int Cost => _cost;
    }
}