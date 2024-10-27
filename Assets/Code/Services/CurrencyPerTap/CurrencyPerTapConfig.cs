using UnityEngine;

namespace Code.Services.CurrencyPerTap
{
    [CreateAssetMenu(menuName = "Clicker/CurrencyPerTapConfig", fileName = "CurrencyPerTapConfig", order = 0)]
    public class CurrencyPerTapConfig : ScriptableObject
    {
        public int BaseSoftCurrencyPerTap;
        public float SoftCurrencyPerTapMultiplier = 1f;
    }
}