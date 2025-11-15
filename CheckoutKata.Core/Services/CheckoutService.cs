using CheckoutKata.Core.PricingRules;

namespace CheckoutKata.Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly Dictionary<string,int> _itemPrices = new Dictionary<string,int>();
        private readonly IPriceRule _priceRule;
        public CheckoutService(IPriceRule priceRule)
        {
            _priceRule = priceRule;
        }

        public int GetTotalPrice()
        {
            return _priceRule.GetPrice("A", _itemPrices.GetValueOrDefault("A"));
        }

        public void Scan(string item)
        {
            _itemPrices[item] = _itemPrices.GetValueOrDefault(item) + 1;
        }
    }
}
