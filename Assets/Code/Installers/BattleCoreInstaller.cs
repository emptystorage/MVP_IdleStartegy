using UnityEngine;
using EmptyDI;
using Code.Core;
using Code.Core.Pools;
using Code.BattleParticipants;

namespace Code.Installers
{
    public sealed class BattleCoreInstaller : MonoInstaller
	{
        [SerializeField] private BattleSceneContext _battleSceneContext;
        [SerializeField] private EnemyWaveSpawner _enemyWaveSpawner;
		[SerializeField] private int _startResourcesCount;
        [SerializeField] private float _battleTime;

		public override void Install()
		{
            this.Bind<WarriorParticipantPool, string, WarriorParticipant>();
            this.Bind<BattleBasePool, string, BattleBase>();

            this.Bind<BattleSceneContext>(_battleSceneContext)
                .AsSingle();

            this.Bind<EnemyWaveSpawner>(_enemyWaveSpawner)
                .AsSingle();

            var distance = Vector3.Distance(_battleSceneContext.EnemySpawnPoint, _battleSceneContext.PlayerSpawnPoint);

            this.Bind<BattleInformation>()
                .WhereParameters(_startResourcesCount, (distance / _battleTime))
                .IsCreated()
                .AsSingle();
        }
    }
}
