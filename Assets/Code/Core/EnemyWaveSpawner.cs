using System;
using UnityEngine;
using EmptyDI;
using Code.Core.Command;
using Code.BattleParticipants;
using Codice.Client.BaseCommands;

namespace Code.Core
{
    public sealed class EnemyWaveSpawner : MonoBehaviour
    {
        [SerializeField] private WaveData[] _waveDatas;
        private int _waveIndex;

        [Inject]
        public void Construct() { }

        private void OnValidate()
        {
            var waveElementName = "<color=green><b>Wave - {0}</b></color>";
            var enemyElementName = "Enemy type of <color=blue><b>{0}</b></color>";
            var errorElementName = "<color=red><b> NOT SET VALUE</b></color>";

            for (int i = 0; i < _waveDatas.Length; i++)
            {
                _waveDatas[i].name = string.Format(waveElementName, i + 1);

                for(int j = 0; j < _waveDatas[i].enemyDatas.Length; j++)
                {
                    if (_waveDatas[i].enemyDatas[j].prefab == null)
                    {
                        _waveDatas[i].enemyDatas[j].name = errorElementName;
                        _waveDatas[i].name += "<color=red><b> <-- !!!</b> <i>(contain error)</i></color>";
                    }
                    else
                        _waveDatas[i].enemyDatas[j].name = string.Format(enemyElementName, _waveDatas[i].enemyDatas[j].prefab.name);
                }
            }
        }

        public void StartBattle()
        {
            CreateWave();
        }

        public void EndBattle()
        {
            StopAllCoroutines();
        }

        private void CreateWave()
        {
            var data = _waveDatas[_waveIndex];
            var cmd = new CommandConstructor<CreateWarriorCommand>().CreateCommand();

            for (int i = 0; i < data.enemyDatas.Length; i++)
            {
                for (int j = 0; j < data.enemyDatas[i].count; j++)
                {
                    cmd.Execute(data.enemyDatas[i].prefab);
                }
            }

            _waveIndex++;

            if (_waveIndex >= _waveDatas.Length) return;

            Invoke(nameof(CreateWave), data.nextWaveTime);
        }

        [Serializable]
        private struct WaveData
        {
            [HideInInspector] public string name;
            public EnemeData[] enemyDatas;
            public float nextWaveTime;
        }

        [Serializable]
        private struct EnemeData
        {
            [HideInInspector] public string name;
            public WarriorParticipant prefab;
            public int count;
        }
    }
}
