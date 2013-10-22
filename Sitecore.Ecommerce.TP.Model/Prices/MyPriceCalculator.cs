using System.Collections.Generic;
using Sitecore.Diagnostics;
using Sitecore.Ecommerce.DomainModel.Prices;

namespace Sitecore.Ecommerce.TP.Model.Prices
{
    public class MyPriceCalculator : PriceCalculator
    {
        // Fields
        private readonly TotalsFactory _totalsFactory;

        // Methods
        public MyPriceCalculator(string priceKey, TotalsFactory totalsFactory)
        {
            Assert.ArgumentNotNullOrEmpty(priceKey, "priceKey");
            Assert.ArgumentNotNull(totalsFactory, "totalsFactory");
            this._totalsFactory = totalsFactory;
            base.PriceKey = priceKey;
        }

        public override Totals Calculate(IDictionary<string, decimal> priceMatrix, decimal vat, uint quantity)
        {
            Assert.ArgumentNotNull(priceMatrix, "priceMatrix");
            decimal num = priceMatrix[base.PriceKey];
            decimal num2 = priceMatrix["NormalPrice"];
            decimal num3 = priceMatrix["MemberPrice"];
            if (num == 0M)
            {
                num = num2;
            }
            if (num3 == 0M)
            {
                num3 = num2;
            }
            Totals totals = this.TotalsFactory.Create();
            totals.PriceExVat = num;
            totals.PriceIncVat = num*(vat + 1);
            totals.MemberPrice = num3;
            totals.VAT = vat;
            if (quantity != 0)
            {
                totals.TotalPriceExVat = totals.PriceExVat*quantity;
                totals.TotalPriceIncVat = totals.PriceIncVat*quantity;
                totals.TotalVat = totals.TotalPriceIncVat - totals.TotalPriceExVat;
                totals.DiscountExVat = (num2 - num)*quantity;
                totals.DiscountIncVat = totals.DiscountExVat*(vat + 1);
                totals.PossibleDiscountExVat = (num - num3)*quantity;
                totals.PossibleDiscountIncVat = totals.PossibleDiscountExVat*(vat + 1);
            }
            return totals;
        }

        // Properties
        protected TotalsFactory TotalsFactory
        {
            get { return this._totalsFactory; }
        }
    }
}
