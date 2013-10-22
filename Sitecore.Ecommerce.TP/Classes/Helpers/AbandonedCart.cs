using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Sitecore.Ecommerce.DomainModel.Carts;

namespace Sitecore.Ecommerce.TP.Classes.Helpers
{
    [Serializable]
    public class AbandonedShoppingCartLine
    {
        public string ProductCode { get; set; }
        public string Quantity { get; set; }
    }

    [Serializable]
    public class AbandonedShoppingCart
    {
        public List<AbandonedShoppingCartLine> ShoppingCartLines { get; set; }
        public string ShippingProviderCode { get; set; }
    }

    public class AbandonedCart
    {
        private void CheckForAbandonedCart()
        {
            var cart = Ecommerce.Context.Entity.GetInstance<Sitecore.Ecommerce.TP.Model.Carts.ShoppingCart>();

            if (cart.AbandonedCartChecked)
                return;

            if (Sitecore.Analytics.Tracker.Visitor == null)
            {
                return;
            }
            var currentVisitor = Sitecore.Analytics.Tracker.Visitor;

            // We should be more clear in how many visits to load.
            currentVisitor.LoadAll();

            var row = currentVisitor.Tags.Find("AbandonedCart");

            if (row == null)
                return;

            var serializedCart = row.TagValue;

            if (String.IsNullOrEmpty(serializedCart))
                return;

            var serializedCartXml = new XmlDocument();

            serializedCartXml.LoadXml(serializedCart);

            var serializer = new XmlSerializer(typeof(AbandonedShoppingCart));

            var abandonedShoppingCart = (AbandonedShoppingCart)serializer.Deserialize(new StringReader(serializedCartXml.OuterXml));

            var shoppingCartHandler = Ecommerce.Context.Entity.Resolve<IShoppingCartManager>();

            foreach (var line in abandonedShoppingCart.ShoppingCartLines)
            {
                shoppingCartHandler.AddProduct(line.ProductCode, uint.Parse(line.Quantity));
            }

            // Indicate that we allready checked for abandoned cart
            cart.AbandonedCartChecked = true;

            // Todo: Set all the other stuff on the ShoppingCart here.

            Ecommerce.Context.Entity.SetInstance(cart);
        }


    }
}