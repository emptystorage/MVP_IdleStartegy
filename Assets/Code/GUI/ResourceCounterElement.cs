using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EmptyDI;
using Code.Core;

namespace Code.GUI
{
    public sealed class ResourceCounterElement : MonoBehaviour
    {

        [SerializeField] private Image _fader;
        [SerializeField] private TextMeshProUGUI _countText;

        [Inject]
        public void Construct(BattleInformation battleInformation)
        {
            BattleInformation = battleInformation;
            _countText.text = BattleInformation.ResourcesValue.Value.ToString();
        }

        private BattleInformation BattleInformation { get; set; }

        private void Start()
        {
            StartCoroutine(UpdateTick(10));
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator UpdateTick(float updateTickTime, float updateTickSpeed = 1)
        {
            var currentTime = updateTickTime;
            var fillAmount = currentTime / updateTickTime;

            while(true)
            {
                currentTime -= updateTickSpeed * Time.deltaTime;                

                if(currentTime <= 0)
                {
                    BattleInformation.ResourcesValue.Value++;
                    _countText.text = BattleInformation.ResourcesValue.Value.ToString();
                    currentTime = updateTickTime;
                }

                fillAmount = currentTime / updateTickTime;
                _fader.fillAmount = fillAmount;

                yield return null;
            }
        }
    }
}
