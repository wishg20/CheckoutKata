
namespace CheckoutKata.Core.PricingRules
{
    /// <summary>
    /// A pricing rule that calculates the total price based on a unit price.
    /// </summary>
    public class UnitPriceRule(int unitPrice) : IPriceRule
    {
        public int Calculate(int quantity)
        {
                return quantity * unitPrice;
        }
    }
}
