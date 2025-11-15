using CheckoutKata.Core.PricingRules;

namespace CheckoutKata.Core.Catalogue
{
    public class PricingRuleCatalogue: IPricingRuleCatalogue
    {
        private Dictionary<string, IPriceRule> _rulesDictionary;

        public PricingRuleCatalogue(Dictionary<string, IPriceRule> rulesDictionary)
        {
            this._rulesDictionary = rulesDictionary;
        }

        public IPriceRule GetPricingRule(string sku)
        {
            if (_rulesDictionary.TryGetValue(sku, out var rule))
            {
                return rule;
            }

            throw new KeyNotFoundException("Unknown SKU: " + sku);
        }
    }
}
