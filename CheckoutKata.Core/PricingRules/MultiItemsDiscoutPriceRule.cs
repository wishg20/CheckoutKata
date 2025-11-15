namespace CheckoutKata.Core.PricingRules
{
    internal class MultiItemsDiscoutPriceRule : IPriceRule
    {
        private int _unitCost;
        private int _offerQuantity;
        private int _specialOffer;

        public MultiItemsDiscoutPriceRule(int unitCost, int offerQuantity, int specialOffer)
        {
            this._unitCost = unitCost;
            this._offerQuantity = offerQuantity;
            this._specialOffer = specialOffer;
        }

        public int Calculate(int quantity)
        {
            int fullDeals = quantity / _offerQuantity;      
            int remainingItems = quantity % _offerQuantity; 

            int dealTotal = fullDeals * _specialOffer;
            int regularTotal = remainingItems * _unitCost;

            return dealTotal + regularTotal;
        }
    }
}
