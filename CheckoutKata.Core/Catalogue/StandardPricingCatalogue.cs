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
                ["A"] = new MultiItemsDiscoutPriceRule(unitCost:50,offerQuantity:3,specialOffer:130),
                ["B"] = new MultiItemsDiscoutPriceRule(unitCost:30,offerQuantity:2, specialOffer:45),
                ["C"] = new UnitPriceRule(20),
                ["D"] = new UnitPriceRule(15)
            });
        }
    }
}
