using UnityEngine;
using EmptyDI;
using Code.GUI;
using Code.Core.Pools;

namespace Code.Installers
{
    public sealed class GUIInstaller : MonoInstaller
    {
        [Header("MAIN ENTITY")]
        [SerializeField] private GUISceneContext _context;
        [SerializeField] private ResourceCounterElement _resourcesElement;
        [SerializeField] private UnitButtonsRootElement _unitButtonsRootElement;

        [Header("PREFABS")]
        [SerializeField] private PlayerWarriorButton _unitButtonPrefab;
        [SerializeField] private UnitBattleInfoUIElement _unitBattleInfoUIElementPrefab;

        public override void Install()
        {
            this.Bind<PlayerWarriorButtonPool, PlayerWarriorButton>(_unitButtonPrefab);
            this.Bind<UnitBattleInfoElementPool, UnitBattleInfoUIElement>(_unitBattleInfoUIElementPrefab);

            this.Bind(_context).AsSingle();
            this.Bind(_resourcesElement).IsCreated().AsSingle();
            this.Bind(_unitButtonsRootElement).IsCreated().AsSingle();
        }
    }
}
