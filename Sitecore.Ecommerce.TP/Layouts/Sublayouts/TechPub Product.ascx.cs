namespace Sitecore.Ecommerce.TP.Layouts.Sublayouts
{
    using System;

    public partial class TechPub_Product : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var cart = Sitecore.Ecommerce.Context.Entity.GetInstance<Sitecore.Ecommerce.DomainModel.Carts.ShoppingCart>();
                
            litPrice.Text =
                Classes.Helpers.PriceHelper.FormatPrice(
                    Classes.Helpers.PriceHelper.GetPrice(Sitecore.Context.Item["product code"]).PriceIncVat, cart.Currency.Title);
        }
    }
}