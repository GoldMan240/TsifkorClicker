using System;
using UnityEngine;
using Zenject;

namespace Code
{
    public class EnergyService : IEnergyService, IInitializable
    {
        public event Action OnEnergyChanged;
        
        public int Energy { get; private set; } = 100;

        public void Initialize()
        {
            ResetEnergy();
        }

        public void RemoveEnergy(int amount)
        {
            Energy -= amount;
            
            if (Energy < 0)
            {
                Energy = 0;
                Debug.LogWarning("Trying to remove more energy than available");
            }
            
            OnEnergyChanged?.Invoke();
        }
        
        private void ResetEnergy()
        {
            Energy = 100;
            OnEnergyChanged?.Invoke();
        }
    }
}