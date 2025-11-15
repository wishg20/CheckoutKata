namespace CheckoutKata.Core.PricingRules
{
    public interface IPriceRule
    {
        int GetPrice(string itemCode, int quantity);
    }
}
