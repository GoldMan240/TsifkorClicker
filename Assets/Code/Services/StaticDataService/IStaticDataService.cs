namespace Code
{
    public interface IStaticDataService
    {
        void LoadAll();
        CurrencyPerTapConfig GetCurrencyPerTapConfig();
    }
}