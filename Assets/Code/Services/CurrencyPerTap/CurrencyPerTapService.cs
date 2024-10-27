using Code.Services.StaticDataService;
using Zenject;

namespace Code.Services.CurrencyPerTap
{
    public class CurrencyPerTapService : ICurrencyPerTapService, IInitializable
    {
        public int SoftCurrencyPerTap => CalculateSoftCurrencyPerTap();
        
        private readonly IStaticDataService _staticDataService;
        private int _softCurrencyPerTap;
        private int _baseSoftCurrencyPerTap;
        private int _additionalCurrencyPerTap;
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
        
        public void SetAdditionalCurrencyPerTap(int additionalCurrencyPerTap) => 
            _additionalCurrencyPerTap = additionalCurrencyPerTap;

        private int CalculateSoftCurrencyPerTap()
        {
            _softCurrencyPerTap = _baseSoftCurrencyPerTap;
            _softCurrencyPerTap = (int)(_softCurrencyPerTap * _softCurrencyPerTapMultiplier);
            _softCurrencyPerTap += _additionalCurrencyPerTap;
            return _softCurrencyPerTap;
        }
    }
}