using CheckoutKata.Core.PricingRules;

namespace CheckoutKata.Core.Catalogue
{
    public class StandardPricingCatalogue
    {
        public static PricingRuleCatalogue GetDefaultPrices()
        {
            return new PricingRuleCatalogue(new Dictionary<string, IPriceRule>
            {
                ["A"] = new UnitPriceRule(50)
            });
        }
    }
}
