namespace CheckoutKata.Core.PricingRules
{
    public interface IPriceRule
    {
        int Calculate(string itemCode, int quantity);
    }
}
