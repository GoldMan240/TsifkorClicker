using System.Collections;
using UnityEngine;
using Zenject;

namespace Code
{
    public class SoftCurrencyAutoCollect : IInitializable
    {
        private ICoroutineRunner _coroutineRunner;
        private IStaticDataService _staticDataService;
        private ICurrencyService _currencyService;
        private ICurrencyPerTapService _currencyPerTapService;
        private float _collectInterval;
        private int _currencyPerInterval;
        private bool _isWorks;

        [Inject]
        private void Construct(ICoroutineRunner coroutineRunner, IStaticDataService staticDataService,
            ICurrencyService currencyService, ICurrencyPerTapService currencyPerTapService)
        {
            _coroutineRunner = coroutineRunner;
            _staticDataService = staticDataService;
            _currencyService = currencyService;
            _currencyPerTapService = currencyPerTapService;
        }

        public void Initialize()
        {
            _isWorks = true;

            SoftCurrencyAutoCollectConfig config = _staticDataService.GetSoftCurrencyAutoCollectConfig();
            _collectInterval = config.CollectInterval;
            _currencyPerInterval = config.CurrencyPerInterval;

            int additionalCurrencyPerTap = (int)(_currencyPerInterval * config.CurrencyPercentagePerTap);
            _currencyPerTapService.SetAdditionalCurrencyPerTap(additionalCurrencyPerTap);
            
            _coroutineRunner.StartCoroutine(CollectSoftCurrency());
        }

        private IEnumerator CollectSoftCurrency()
        {
            while (_isWorks)
            {
                yield return new WaitForSeconds(_collectInterval);
                _currencyService.AddSoftCurrency(_currencyPerInterval);
            }
        }
    }
}