using System.Linq;
using Sitecore.Ecommerce.DomainModel.Carts;
using Sitecore.Form.Core.Controls.Data;

namespace Sitecore.Ecommerce.TP.Classes.Wffm.Actions
{
    public class AddToBasketAction : Sitecore.Form.Submit.ISaveAction
    {
        public void Execute(Sitecore.Data.ID formid, Form.Core.Client.Data.Submit.AdaptedResultList fields, params object[] data)
        {
            var values = "";

            foreach (AdaptedControlResult field in fields)
            {
                if (values.Length > 0)
                    values += "&";

                values += field.FieldName + "=" + field.Value;
            }

            var manager = Sitecore.Ecommerce.Context.Entity.Resolve<IShoppingCartManager>();

            manager.AddProduct(Sitecore.Context.Item["product code"], 1);

            var cart = Sitecore.Ecommerce.Context.Entity.GetInstance<ShoppingCart>();

            var line = cart.ShoppingCartLines.Last() as Sitecore.Ecommerce.TP.Model.Carts.ShoppingCartLine;

            line.FormData = values;

            Sitecore.Ecommerce.Context.Entity.SetInstance(cart);
        }
    }
}