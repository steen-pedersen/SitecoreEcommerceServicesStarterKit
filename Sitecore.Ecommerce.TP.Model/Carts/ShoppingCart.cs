using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Sitecore.Ecommerce.TP.Model.Carts
{
    [Serializable]
    public class ShoppingCart : Sitecore.Ecommerce.Carts.ShoppingCart
    {
        public long ProductCount()
        {
            return ShoppingCartLines.Aggregate<DomainModel.Carts.ShoppingCartLine, long>(0, (current, line) => current + line.Quantity);
        }

        public bool AbandonedCartChecked { get; set; }

        
        public void SerializeCartToDms()
        {
            Diagnostics.Log.Info("CheckAndSaveAbandonedCart - start. ", new object());

            /*try
            {
                if (Analytics.Tracker.Visitor == null)
                {
                    Diagnostics.Log.Info("CheckAndSaveAbandonedCart - Visitor is null at this point. ", new object());
                    return;
                }

                if (ProductCount() <= 0)
                    return;

                // Create our serializeable cart object and set shipping provider code
                var abandonedCart = new AbandonedShoppingCart
                {
                    ShippingProviderCode = ShippingProvider.Code,
                    ShoppingCartLines =
                        new List<AbandonedShoppingCartLine>()
                };

                // Save the product lines
                foreach (var line in ShoppingCartLines)
                {
                    abandonedCart.ShoppingCartLines.Add(new AbandonedShoppingCartLine { ProductCode = line.Product.Code, Quantity = line.Quantity.ToString() });
                }

                var serializer = new XmlSerializer(abandonedCart.GetType());
                var stringWriter = new StringWriter();
                var writer = XmlWriter.Create(stringWriter);
                serializer.Serialize(writer, abandonedCart);
                var serializedXml = stringWriter.ToString();

                // Save the serialized cart as a tag.
                Analytics.Tracker.Visitor.Tags.Set("AbandonedCart", serializedXml);
            }
            catch (Exception exp)
            {
                Diagnostics.Log.Error("CheckAndSaveAbandonedCart - Error : " + exp.Message, new object());
            }*/
        }
    }

    
}
