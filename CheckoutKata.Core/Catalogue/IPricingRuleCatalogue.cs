using CheckoutKata.Core.PricingRules;

namespace CheckoutKata.Core.Catalogue
{
    public interface IPricingRuleCatalogue
    {
        IPriceRule GetPricingRule(string sku);
    }
}
