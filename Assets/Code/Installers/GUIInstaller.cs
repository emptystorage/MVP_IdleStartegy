using UnityEngine;
using EmptyDI;
using Code.GUI;

namespace Code.Installers
{
    public sealed class GUIInstaller : MonoInstaller
    {
        [SerializeField] private ResourceCounterElement _resourcesElement;

        public override void Install()
        {
            this.Bind(_resourcesElement).IsCreated().AsSingle();
        }
    }
}
