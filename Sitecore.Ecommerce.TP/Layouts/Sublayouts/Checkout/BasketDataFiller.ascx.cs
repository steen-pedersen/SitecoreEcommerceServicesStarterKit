using Sitecore.Ecommerce.DomainModel.Data;
using Sitecore.Ecommerce.DomainModel.Orders;
using Sitecore.Ecommerce.DomainModel.Payments;
using Sitecore.Ecommerce.DomainModel.Shippings;
using System;

namespace Sitecore.Ecommerce.TP.Layouts.Sublayouts.Checkout
{
    public partial class BasketDataFiller : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Get the current cart
            var cart = Sitecore.Ecommerce.Context.Entity.GetInstance<Sitecore.Ecommerce.Carts.ShoppingCart>();

            // Check if we have any lines
            if (cart.ShoppingCartLines.Count > 0)
            {
                var addressInfo = new Addresses.AddressInfo
                                      {
                                          Name = "My Name",
                                          Address = "MyAddress",
                                          City = "MyCity",
                                          Zip = "1234"
                                      };

                var countries = Ecommerce.Context.Entity.Resolve<IEntityProvider<DomainModel.Addresses.Country>>();

                // Set the default country
                addressInfo.Country = countries.Get("DK");

                // Populate the AddressInfos
                cart.CustomerInfo.ShippingAddress = addressInfo;
                cart.CustomerInfo.BillingAddress = addressInfo;

                cart.CustomerInfo.Email = "sp@sitecore.net";

                // Set a order number
                cart.OrderNumber = DateTime.Now.ToString("ddMMyyyyhhmmss");

                // Set a payment system
                var provider = Ecommerce.Context.Entity.Resolve<IEntityProvider<PaymentSystem>>();
                cart.PaymentSystem = provider.GetDefault();

                // Set a shipping provider
                var shippingProvider =
                    Sitecore.Ecommerce.Context.Entity.Resolve<IEntityProvider<ShippingProvider>>().Get("Shop");
                cart.ShippingProvider = shippingProvider;

                // Save cart
                Sitecore.Ecommerce.Context.Entity.SetInstance(cart);

                Ecommerce.Context.Entity.Resolve<ITransactionData>()
                         .SaveStartValues(cart.OrderNumber, cart.Totals.TotalPriceExVat.ToString(), cart.Currency.Code,
                                          cart.PaymentSystem.Code);


                // Get a Order Manager
                var om = Ecommerce.Context.Entity.Resolve<IOrderManager<Order>>();

                // Create the order
                var order = om.CreateOrder(cart);
            }


        }
    }
}