using System;
using System.Globalization;
using Sitecore.Diagnostics;
using Sitecore.Ecommerce.DomainModel.Currencies;
using Sitecore.Ecommerce.DomainModel.Products;
using Sitecore.Ecommerce.Prices;
using Totals = Sitecore.Ecommerce.DomainModel.Prices.Totals;

namespace Sitecore.Ecommerce.TP.Classes.Helpers
{
    public static class PriceHelper
    {
        /// <summary>
        /// The product price manager instance.
        /// </summary>
        private static ProductPriceManager _productPriceManager;

        /// <summary>
        /// Gets or sets the product price manager.
        /// </summary>
        /// <value>
        /// The product price manager.
        /// </value>
        [NotNull]
        public static ProductPriceManager ProductPriceManager
        {
            get
            {
                return _productPriceManager ?? (_productPriceManager = Context.Entity.Resolve<ProductPriceManager>());
            }

            set
            {
                Assert.ArgumentNotNull(value, "value");

                _productPriceManager = value;
            }
        }

        public static Totals GetPrice(string productCode)
        {
            var product = Context.Entity.Resolve<IProductRepository>().Get<ProductBaseData>(productCode);

            if (product != null)
            {
                var cart = Context.Entity.GetInstance<DomainModel.Carts.ShoppingCart>();

                return
                    ProductPriceManager.GetProductTotals<Totals, ProductBaseData, Currency>(product, cart.Currency);
            }

            return null;
        }

        public static string FormatPrice(decimal price)
        {
            return FormatPrice(price, String.Empty);
        }

        public static string FormatPrice(decimal price, string suffix)
        {
            // We get the cultureinfo from context language.
            var cultureInfo = CultureInfo.CreateSpecificCulture(Sitecore.Context.Language.CultureInfo.TwoLetterISOLanguageName);

            // We format it to always have 2 digits and thousand separator
            var formattedAmount = String.Format(cultureInfo, "{0:N2}", price);

            return formattedAmount + suffix;
        }
    }
}