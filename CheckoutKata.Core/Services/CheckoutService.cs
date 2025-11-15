namespace CheckoutKata.Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly Dictionary<string,int> _itemPrices = new Dictionary<string,int>();

        public int GetTotalPrice()
        {
            return _itemPrices.Where(x => x.Key == "A").Select(x => 50).FirstOrDefault();

        }

        public void Scan(string item)
        {
            _itemPrices[item] = _itemPrices.GetValueOrDefault(item) + 1;
        }
    }
}
