using Sitecore.Ecommerce.DomainModel.Carts;

namespace Sitecore.Ecommerce.TP.Layouts.Sublayouts
{
    using System;

    public partial class TechPub_SmallCart : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var cart = Sitecore.Ecommerce.Context.Entity.GetInstance<ShoppingCart>();

            if (cart.ShoppingCartLines.Count == 0)
            {
            litSmallCart.Text = "Cart is empty";
            }
            else
            {
                litSmallCart.Text = "Yeha we have something in the basket with the total of " +
                                    cart.Totals.TotalPriceIncVat;
                ;
            }
        


           
        }
    }
}