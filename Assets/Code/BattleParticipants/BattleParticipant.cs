using Code.Core;
using EmptyDI;
using System;
using UnityEngine;

namespace Code.BattleParticipant
{
    public abstract class BattleParticipant : MonoBehaviour, IHitable
    {
        public virtual Team Team { get; private set; }
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }

        protected BattleInformation BattleInformation { get; private set; }

        public event Action<int, int> ChangeHealth;
        public event Action Dead;

        [Inject]
        public void Construct(BattleInformation battleInformation)
        {
            BattleInformation = battleInformation;
        }

        private void OnDestroy()
        {
            BattleInformation = null;
        }

        private void OnEnable()
        {
            BattleInformation.AddUnit(this);
        }

        private void OnDisable()
        {
            BattleInformation.RemoveUnit(this);
        }

        public virtual void Setup()
        {
            //TODO setup some unit by data
        }

        public void Hit(int damage)
        {
            CurrentHealth -= damage;

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
    }
}
