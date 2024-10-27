using Code.Services.Energy;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Gameplay
{
    public class EnergyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private IEnergyService _energyService;

        [Inject]
        private void Construct(IEnergyService energyService)
        {
            _energyService = energyService;
        }

        private void Awake()
        {
            _energyService.OnEnergyChanged += OnEnergyChanged;
        }

        private void OnDestroy()
        {
            _energyService.OnEnergyChanged -= OnEnergyChanged;
        }

        private void OnEnergyChanged()
        {
            _text.text = _energyService.Energy.ToString();
        }
    }
}