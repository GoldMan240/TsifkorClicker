using UnityEngine;

namespace Code
{
    [CreateAssetMenu(menuName = "Clicker/SoftCurrencyAutoCollectConfig", fileName = "SoftCurrencyAutoCollectConfig", order = 0)]
    public class SoftCurrencyAutoCollectConfig : ScriptableObject
    {
        public int CurrencyPerInterval;
        public float CollectInterval;
        public float CurrencyPercentagePerTap;
    }
}