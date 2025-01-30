using Code.BattleParticipants;
using Code.Core.Pools;
using EmptyDI;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Code.GUI
{
    [RequireComponent (typeof (CanvasGroup))]
    public sealed class UnitBattleInfoUIElement : MonoBehaviour
    {
        private UnitBattleInfoElementPool _pool;
        private CanvasGroup _canvasGroup;
        private BattleParticipant _target;
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _fillImage;


        [Inject]
        public void Construct(UnitBattleInfoElementPool pool)
        {
            _pool = pool;
        }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnDisable()
        {
            _target.ChangeHealth -= OnChangeValue;
            _target.Dead -= OnDead;
        }

        private void OnDestroy()
        {
            OnDisable();
        }

        private void LateUpdate()
        {
            if (_target == null) return;
                transform.position = Camera.main.WorldToScreenPoint(_target.transform.position);
        }

        public void Setup(in BattleParticipant target)
        {
            _target = target;
            _target.ChangeHealth += OnChangeValue;
            _target.Dead += OnDead;

            _slider.maxValue = target.MaxHealth;
            _slider.value = target.CurrentHealth;
            _fillImage.color = target.Team == Team.Player ? Color.green : Color.red;
            _canvasGroup.alpha = 0;
        }

        public void Setup(int value, Color color)
        {
            _slider.maxValue = value;
            _slider.value = value;
            _fillImage.color = color;
            _canvasGroup.alpha = 0;
        }

        private void OnChangeValue(int value, int maxValue)
        {
            _slider.value = value;

            if(value < maxValue)
            {
                _canvasGroup.alpha = 1;
            }
            else
            {
                _canvasGroup.alpha = 0;
            }
        }

        private void OnDead(IHitable target)
        {
            _pool.Despawn(this);
            _target.ChangeHealth -= OnChangeValue;
            _target.Dead -= OnDead;
        }
    }
}