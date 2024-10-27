using UnityEngine;

namespace Code.Services.UI
{
    public interface IUiService
    {
        Vector3 GetEnergyViewPosition();
        Vector3 GetSoftCurrencyViewPosition();
    }
}