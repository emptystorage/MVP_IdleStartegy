using Code.Core;
using Code.GameData;
using EmptyDI;
using System;
using System.Collections;
using UnityEngine;

namespace Code.BattleParticipants
{
    public abstract class BattleParticipant : MonoBehaviour, IHitable
    {
        [SerializeField] private Team _team;

        public Team Team => _team;
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int Armor { get; private set; }

        protected BattleInformation BattleInformation { get; private set; }

        public event Action<int, int> ChangeHealth;
        public event Action Dead;

        [Inject]
        public void Construct(BattleInformation battleInformation)
        {
            BattleInformation = battleInformation;
        }

        protected virtual void OnDestroy()
        {
            StopAllCoroutines();
            BattleInformation = null;
        }

        private void OnEnable() => StartCoroutine(Activate());

        private void OnDisable()
        {
            StopAllCoroutines();
            BattleInformation.RemoveUnit(this);
        }

        public abstract void Setup();

        public void Hit(int damage)
        {
            CurrentHealth -= (damage - Armor);

            if (CurrentHealth <= 0) 
            {
                CurrentHealth = 0;
                Dead?.Invoke();
            }
            else
            {
                ChangeHealth?.Invoke(CurrentHealth, MaxHealth);
            }
        }

        protected void SetData(HealthBattleData data)
        {
            MaxHealth = data.Health;
            CurrentHealth = data.Health;
            Armor = data.Armor;
        }

        private IEnumerator Activate()
        {
            yield return new WaitWhile(() => BattleInformation == null);
            BattleInformation.AddUnit(this);
        }
    }
}
