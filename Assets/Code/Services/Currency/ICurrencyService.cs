using System;

namespace Code
{
    public interface ICurrencyService
    {
        event Action OnSoftCurrencyChanged;
        int SoftCurrency { get; }
        void AddSoftCurrency(int amount);
    }
}