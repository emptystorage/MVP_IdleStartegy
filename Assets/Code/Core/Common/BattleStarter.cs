using System.Collections;
using UnityEngine;
using EmptyDI;
using Code.BattleParticipants;
using Code.Core.Command;

namespace Code.Core.Common
{
    public sealed class BattleStarter : MonoBehaviour
    {
        [SerializeField] private BattleBase _playerBasePrefab;
        [SerializeField] private BattleBase _enemyBasePrefab;

        private IEnumerator Start()
        {
            yield return null;

            var cmd = EmptyDIConnector.Get<StartBattleCommand>();
            cmd.Execute(_playerBasePrefab, _enemyBasePrefab);
        }
    }
}
