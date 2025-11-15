namespace CheckoutKata.Core.PricingRules
{
    /// <summary>
    /// A pricing rule that calculates the total price based on a unit price.
    /// </summary>
    public class UnitPriceRule: IPriceRule
    {
        public int GetPrice(string itemCode, int quantity)
        {
            if (itemCode == "A")
            {
                return quantity * 50;
            }
            return 0;
        }
    }
}
