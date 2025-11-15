using CheckoutKata.Core.Catalogue;

namespace CheckoutKata.Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly Dictionary<string,int> _itemPrices = new Dictionary<string,int>();
        private readonly IPricingRuleCatalogue _pricingRuleCatalogue;
        public CheckoutService(IPricingRuleCatalogue pricingRuleCatalogue)
        {
            _pricingRuleCatalogue = pricingRuleCatalogue;
        }

        public int GetTotalPrice()
        {
            return _pricingRuleCatalogue.GetPricingRule("A").Calculate("A", _itemPrices.GetValueOrDefault("A"));
        }

        public void Scan(string item)
        {
            _itemPrices[item] = _itemPrices.GetValueOrDefault(item) + 1;
        }
    }
}
