namespace Code.Services.CurrencyPerTap
{
    public interface ICurrencyPerTapService
    {
        int SoftCurrencyPerTap { get; }
        void SetAdditionalCurrencyPerTap(int additionalCurrencyPerTap);
    }
}