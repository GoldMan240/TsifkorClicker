using UnityEngine;

namespace Code
{
    public class StaticDataService : IStaticDataService
    {
        private CurrencyPerTapConfig _currencyPerTapConfig;
        private SoftCurrencyAutoCollectConfig _softCurrencyAutoCollectConfig;
        
        public void LoadAll()
        {
            LoadCurrencyPerTapConfig();
            LoadSoftCurrencyAutoCollectConfig();
        }
        
        public CurrencyPerTapConfig GetCurrencyPerTapConfig() => 
            _currencyPerTapConfig;
        
        public SoftCurrencyAutoCollectConfig GetSoftCurrencyAutoCollectConfig() => 
            _softCurrencyAutoCollectConfig;

        private void LoadCurrencyPerTapConfig() => 
            _currencyPerTapConfig = Resources.Load<CurrencyPerTapConfig>("Configs/CurrencyPerTapConfig");
        
        private void LoadSoftCurrencyAutoCollectConfig() => 
            _softCurrencyAutoCollectConfig = Resources.Load<SoftCurrencyAutoCollectConfig>("Configs/SoftCurrencyAutoCollectConfig");
    }
}