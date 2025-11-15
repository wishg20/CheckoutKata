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
            int total = 0;
            foreach (var item in _itemPrices)
            {
                total+= _pricingRuleCatalogue.GetPricingRule(item.Key).Calculate(_itemPrices.GetValueOrDefault(item.Key));
            }
            return total;
        }

        public void Scan(string item)
        {
            _itemPrices[item] = _itemPrices.GetValueOrDefault(item) + 1;
        }
    }
}
