using UnityEngine;
using EmptyDI;
using Code.Core;
using Code.Core.Pools;
using Code.BattleParticipants;

namespace Code.Installers
{
    public sealed class BattleCoreInstaller : MonoInstaller
	{
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Transform _enemySpawnPoint;
		[SerializeField] private int _startResourcesCount;

		public override void Install()
		{
            this.Bind<WarriorParticipantPool, string, WarriorParticipant>();

            this.Bind<BattleSceneContex>()
                .WhereParameters(_playerSpawnPoint, _enemySpawnPoint)
                .AsSingle();

            this.Bind<BattleInformation>()
                .WhereParameters(_startResourcesCount)
                .IsCreated()
                .AsSingle();
        }
    }
}
