using System;
using UnityEngine;

namespace Code.GUI
{
    [Serializable]
    public sealed class GUISceneContext : IDisposable
    {
        [SerializeField] private Transform _unitBattleInfoElementRoot;

        public Transform UnitBattleInfoElementRoot => _unitBattleInfoElementRoot;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
