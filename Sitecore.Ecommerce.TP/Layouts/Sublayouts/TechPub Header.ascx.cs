namespace Sitecore.Ecommerce.TP.Layouts.Sublayouts
{
    using System;

    public partial class TechPub_Header : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            var homePath = Sitecore.Context.Site.ContentStartPath + Sitecore.Context.Site.StartItem;
            var homeItem = Sitecore.Context.Database.GetItem(homePath);

            sctxtTitle.Item = homeItem;
            scimg1.Item = homeItem;
        }
    }
}