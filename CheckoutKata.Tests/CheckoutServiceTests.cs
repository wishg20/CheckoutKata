using CheckoutKata.Core.Catalogue;
using CheckoutKata.Core.Services;

namespace CheckoutKata.Tests
{
    public class Tests
    {
        private ICheckoutService _checkoutService;
        private IPricingRuleCatalogue _pricingRuleCatalogue;
        [SetUp]
        public void Setup()
        {
            _pricingRuleCatalogue = StandardPricingCatalogue.GetDefaultPrices();
            _checkoutService = new CheckoutService(_pricingRuleCatalogue);
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

        [Test]
        public void Scan_TwoItems_ShouldReturn80()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(80));
        }
    }
}