using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code
{
    public class SoftCurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private ICurrencyService _currencyService;

        [Inject]
        private void Construct(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        private void Awake()
        {
            _currencyService.OnSoftCurrencyChanged += OnSoftCurrencyChanged;
        }

        private void OnDestroy()
        {
            _currencyService.OnSoftCurrencyChanged -= OnSoftCurrencyChanged;
        }

        private void OnSoftCurrencyChanged()
        {
            _text.text = _currencyService.SoftCurrency.ToString();
        }
    }
}