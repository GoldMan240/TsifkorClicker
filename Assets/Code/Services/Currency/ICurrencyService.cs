using System;

namespace Code.Services.Currency
{
    public interface ICurrencyService
    {
        event Action OnSoftCurrencyChanged;
        int SoftCurrency { get; }
        void AddSoftCurrency(int amount);
    }
}