using CheckoutKata.Core.PricingRules;
using CheckoutKata.Core.Services;

namespace CheckoutKata.Tests
{
    public class Tests
    {
        private ICheckoutService _checkoutService;
        private  IPriceRule _priceRule;
        [SetUp]
        public void Setup()
        {
            _priceRule = new UnitPriceRule();
            _checkoutService = new CheckoutService(_priceRule);
        }

        [Test]
        public void EmptyCheckout_ReturnsZero()
        {
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(0));
        }

        [Test]
        public void Scan_SingleItem_ReturnsUnitPrice()
        {
            _checkoutService.Scan("A");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(50));
        }
    }
}