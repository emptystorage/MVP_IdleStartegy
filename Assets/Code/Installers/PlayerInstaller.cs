using UnityEngine;
using EmptyDI;
using Code.Core;
using Code.GameData;

namespace Code.Installers
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private UnitData[] _unitData;

        public override void Install()
        {
            this.Bind<PlayerInformation>()
                .WhereParameters(_unitData)
                .IsCreated()
                .AsSingle();
            //TODO load save or info from server
        }
    }
}
