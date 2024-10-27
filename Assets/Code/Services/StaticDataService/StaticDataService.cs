using UnityEngine;

namespace Code
{
    public class StaticDataService : IStaticDataService
    {
        private CurrencyPerTapConfig _currencyPerTapConfig;
        
        public void LoadAll()
        {
            LoadCurrencyPerTapConfig();
        }
        
        public CurrencyPerTapConfig GetCurrencyPerTapConfig() => 
            _currencyPerTapConfig;

        private void LoadCurrencyPerTapConfig() => 
            _currencyPerTapConfig = Resources.Load<CurrencyPerTapConfig>("Configs/CurrencyPerTapConfig");
    }
}