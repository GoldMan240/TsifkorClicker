using Code.Services.Currency;
using Code.Services.CurrencyPerTap;
using Code.Services.Energy;
using Code.Services.FloatingText;
using Code.Services.UI;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.ClickerObject
{
    public class ClickerObjectController : MonoBehaviour
    {
        [SerializeField] private ClickerObjectView _view;

        private const int EnergyPerClick = 1;
        private ICurrencyService _currencyService;
        private IEnergyService _energyService;
        private ICurrencyPerTapService _currencyPerTapService;
        private IUiService _uiService;
        private IFloatingTextService _floatingTextService;

        [Inject]
        private void Construct(ICurrencyService currencyService, IEnergyService energyService,
            ICurrencyPerTapService currencyPerTapService, IUiService uiService, IFloatingTextService floatingTextService)
        {
            _currencyPerTapService = currencyPerTapService;
            _energyService = energyService;
            _currencyService = currencyService;
            _uiService = uiService;
            _floatingTextService = floatingTextService;
        }

        private void Awake()
        {
            _view.OnClick += OnClickHandler;
            _energyService.OnEnergyChanged += OnEnergyChangedHandler;
        }

        private void OnDestroy()
        {
            _view.OnClick -= OnClickHandler;
            _energyService.OnEnergyChanged -= OnEnergyChangedHandler;
        }

        private void OnClickHandler()
        {
            _energyService.RemoveEnergy(EnergyPerClick);
            
            int softCurrencyAmount = _currencyPerTapService.SoftCurrencyPerTap;
            _floatingTextService.SetupText(
                softCurrencyAmount.ToString(),
                transform.position,
                _uiService.GetSoftCurrencyViewPosition(),
                () => _currencyService.AddSoftCurrency(softCurrencyAmount));
        }

        private void OnEnergyChangedHandler()
        {
            _view.SetInteractable(_energyService.Energy > 0);
        }
    }
}