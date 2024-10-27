namespace Code
{
    public interface ICurrencyPerTapService
    {
        int SoftCurrencyPerTap { get; }
        void SetAdditionalCurrencyPerTap(int additionalCurrencyPerTap);
    }
}