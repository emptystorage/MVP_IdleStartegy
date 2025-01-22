using UnityEngine;
using EmptyDI;
using Code.Core.Pools;
using Code.GameData;
using Code.Core;

namespace Code.GUI
{
    public sealed class UnitButtonsRootElement : MonoBehaviour
    {
        private PlayerWarriorButtonPool _pool;
        private PlayerInformation _playerInformation;
        [SerializeField] private Transform _removePivotPoint;
        [SerializeField] private Transform _createPivotPoint;
        [SerializeField] private float _slideSpeed;
        [SerializeField] private float _delay;

        [Inject]
        public void Construct(PlayerWarriorButtonPool pool, PlayerInformation playerInformation)
        {
            _pool = pool;
            _playerInformation = playerInformation;
        }

        public Transform RemovePivotPoint => _removePivotPoint;
        public Transform CreatePivotPoint => _createPivotPoint;
        public float SlideSpeed => _slideSpeed;


        private void Start()
        {
            InvokeRepeating(nameof(CreateUnitButton), default, _delay);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void CreateUnitButton()
        {
            _pool.Spawn(this, _playerInformation.UnitData[Random.Range(default, _playerInformation.UnitData.Count)]);
        }
    }
}
