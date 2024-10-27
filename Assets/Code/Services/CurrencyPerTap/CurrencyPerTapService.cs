using UnityEngine;
using Zenject;

namespace Code
{
    public class CurrencyPerTapService : ICurrencyPerTapService, IInitializable
    {
        public int SoftCurrencyPerTap => CalculateSoftCurrencyPerTap();
        
        private readonly IStaticDataService _staticDataService;
        private int _softCurrencyPerTap;
        private int _baseSoftCurrencyPerTap;
        private float _softCurrencyPerTapMultiplier;

        public CurrencyPerTapService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            CurrencyPerTapConfig config = _staticDataService.GetCurrencyPerTapConfig();
            
            _baseSoftCurrencyPerTap = config.BaseSoftCurrencyPerTap;
            _softCurrencyPerTapMultiplier = config.SoftCurrencyPerTapMultiplier;
        }

        private int CalculateSoftCurrencyPerTap()
        {
            _softCurrencyPerTap = _baseSoftCurrencyPerTap;
            _softCurrencyPerTap = (int)(_softCurrencyPerTap * _softCurrencyPerTapMultiplier);
            return _softCurrencyPerTap;
        }
    }
}