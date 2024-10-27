using Code.Gameplay.AutoCollect;
using Code.Services.CurrencyPerTap;

namespace Code.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void LoadAll();
        CurrencyPerTapConfig GetCurrencyPerTapConfig();
        SoftCurrencyAutoCollectConfig GetSoftCurrencyAutoCollectConfig();
    }
}