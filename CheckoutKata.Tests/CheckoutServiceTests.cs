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

        [Test]
        public void Scanning_AA_ShouldReturn100()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(100));
        }

        [Test]
        public void Scanning_C_ShouldReturn20()
        {
            _checkoutService.Scan("C");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(20));
        }

        [Test]
        public void Scanning_DD_ShouldReturn30()
        {
            _checkoutService.Scan("D");
            _checkoutService.Scan("D");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(30));
        }

        [Test]
        public void Scanning_Invalid_item_ReturnException()
        {
            _checkoutService.Scan("E");
            Assert.Throws<KeyNotFoundException>(() => _checkoutService.GetTotalPrice());
        }

        /// <summary>
        /// Multi offer test : 3 for 130 on item A
        /// </summary>
        [Test]
        public void Scanning_AAA_ShouldReturn130()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(130));
        }

        [Test]
        public void Scanning_AAAA_ShouldReturn180()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(180));
        }

        [Test]
        public void Scanning_BB_ShouldReturn45()
        {
            _checkoutService.Scan("B");
            _checkoutService.Scan("B");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(45));
        }
        [Test]
        public void Scanning_BBBA_ShouldReturn125()
        {
            _checkoutService.Scan("B");
            _checkoutService.Scan("B");
            _checkoutService.Scan("B");
            _checkoutService.Scan("A");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(125));
        }

        [Test]
        public void Scanning_BAB_ShouldReturn95()
        {
            _checkoutService.Scan("B");
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");
            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(95));
        }

        [Test]
        public void Scanning_AAA_BB_C_D_ShouldReturn210()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");
            _checkoutService.Scan("B");
            _checkoutService.Scan("C");
            _checkoutService.Scan("D");

            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(210));
        }

        [Test]
        public void Scanning_D_C_BAB_AAShouldReturn210()
        {
            _checkoutService.Scan("D");
            _checkoutService.Scan("C");
            _checkoutService.Scan("B");
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");

            var totalPrice = _checkoutService.GetTotalPrice();

            Assert.That(totalPrice, Is.EqualTo(210));
        }
        [Test]
        public void Scanning_A_B_C_E_ShouldReturnException()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");
            _checkoutService.Scan("C");
            _checkoutService.Scan("E");

            Assert.Throws<KeyNotFoundException>(() => _checkoutService.GetTotalPrice());

        }
    }
}