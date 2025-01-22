using UnityEngine;
using EmptyDI;
using Code.GUI;
using Code.Core.Pools;

namespace Code.Installers
{
    public sealed class GUIInstaller : MonoInstaller
    {
        [SerializeField] private ResourceCounterElement _resourcesElement;
        [SerializeField] private UnitButtonsRootElement _unitButtonsRootElement;
        [SerializeField] private PlayerWarriorButton _unitButtonPrefab;

        public override void Install()
        {
            this.Bind<PlayerWarriorButtonPool, PlayerWarriorButton>(_unitButtonPrefab);

            this.Bind(_resourcesElement).IsCreated().AsSingle();
            this.Bind(_unitButtonsRootElement).IsCreated().AsSingle();
        }
    }
}
