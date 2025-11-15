using CheckoutKata.Core.PricingRules;

namespace CheckoutKata.Core.Catalogue
{
    /// <summary>
    /// A - 50 - 3 for 130
    /// B - 30 - 2 for 45
    /// C - 20
    /// D - 15
    /// </summary>
    public class StandardPricingCatalogue
    {
        public static PricingRuleCatalogue GetDefaultPrices()
        {
            return new PricingRuleCatalogue(new Dictionary<string, IPriceRule>
            {
                ["A"] = new UnitPriceRule(50),
                ["B"] = new UnitPriceRule(30),
                ["C"] = new UnitPriceRule(20),
                ["D"] = new UnitPriceRule(15)
            });
        }
    }
}
