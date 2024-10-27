using System;

namespace Code
{
    public interface IEnergyService
    {
        int Energy { get; }
        event Action OnEnergyChanged;
        void RemoveEnergy(int amount);
    }
}