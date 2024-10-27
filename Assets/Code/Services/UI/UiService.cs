using Code.Gameplay;
using UnityEngine;

namespace Code.Services.UI
{
    public class UiService : MonoBehaviour, IUiService
    {
        [SerializeField] private EnergyView _energyView;
        [SerializeField] private SoftCurrencyView _softCurrencyView;
        
        public Vector3 GetEnergyViewPosition() => 
            _energyView.transform.position;
        
        public Vector3 GetSoftCurrencyViewPosition() =>
            _softCurrencyView.transform.position;
    }
}