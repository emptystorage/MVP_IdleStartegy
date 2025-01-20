using UnityEngine;
using EmptyDI;
using Code.Core;

namespace Code.Installers
{

    public sealed class BattleCoreInstaller : MonoInstaller
	{
		[SerializeField] private int _startResourcesCount;

		public override void Install()
		{
            this.Bind<BattleInformation>()
                .WhereParameters(_startResourcesCount)
                .IsCreated()
                .AsSingle();
        }
    }
}
