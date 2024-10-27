using System;

namespace Code.Services.Energy
{
    public interface IEnergyService
    {
        int Energy { get; }
        event Action OnEnergyChanged;
        void RemoveEnergy(int amount);
    }
}