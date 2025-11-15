namespace CheckoutKata.Core.PricingRules
{
    public interface IPriceRule
    {
        int Calculate(int quantity);
    }
}
