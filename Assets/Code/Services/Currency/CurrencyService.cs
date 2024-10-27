using System;
using Zenject;

namespace Code
{
    public class CurrencyService : ICurrencyService, IInitializable
    {
        public event Action OnSoftCurrencyChanged;

        public int SoftCurrency { get; private set; }

        public void Initialize()
        {
            ResetSoftCurrency();
        }

        public void AddSoftCurrency(int amount)
        {
            SoftCurrency += amount;
            OnSoftCurrencyChanged?.Invoke();
        }

        private void ResetSoftCurrency()
        {
            SoftCurrency = 0;
            OnSoftCurrencyChanged?.Invoke();
        }
    }
}