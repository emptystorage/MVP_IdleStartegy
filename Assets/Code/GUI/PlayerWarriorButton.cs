using Code.Core;
using Code.Core.Command;
using Code.Core.Pools;
using Code.GameData;
using EmptyDI;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.GUI
{
    [RequireComponent(typeof(Button))]
    public sealed class PlayerWarriorButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _resourcesCostText;
        [SerializeField] private Image _unitIcon;
        [SerializeField] private GameObject _soldRoot;
        private Transform _point;
        private Button _button;
        private PlayerWarriorButtonPool _pool;
        private BattleInformation _battleInformation;
        private PlayerWarriorData _data;
        private float _speed;

        [Inject]
        public void Construct(PlayerWarriorButtonPool pool, BattleInformation battleInformation)
        {
            _pool = pool;
            _battleInformation = battleInformation;
        }

        public void Setup(PlayerWarriorData data, Transform point, float speed)
        {
            _data = data;
            _point = point;
            _speed = speed;
            _resourcesCostText.text = _data.Cost.ToString();
            _unitIcon.sprite = _data.Icon;
            _soldRoot.SetActive(false);
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnEnable()
        {
            StartCoroutine(MoveTo());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnClick()
        {
            if(_data.Cost <= _battleInformation.ResourcesValue.Value)
            {
                _battleInformation.ResourcesValue.Value -= _data.Cost;
                _soldRoot.SetActive(true);

                var cmd = new CommandFactory<CreateWarriorCommand>().Create();
                cmd.Execute(_data.Prefab);
            }
            else
            {
                //TODO show popup not resources
            }
        }

        private IEnumerator MoveTo()
        {
            yield return new WaitWhile(() => _point == null);

            while (true)
            {
                transform.position -= Vector3.right * _speed * 100 * Time.deltaTime;

                if(transform.position.x <= _point.position.x)
                {
                    _pool.Despawn(this);
                }

                yield return null;
            }
        }
    }
}
