namespace Sitecore.Ecommerce.TP.Layouts.Sublayouts
{
    using System;

    public partial class UnityCheck : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var container = Sitecore.Ecommerce.Context.Entity.Registrations;

            foreach (var containerRegistration in container)
            {
                if (containerRegistration.MappedToType.ToString().StartsWith("Sitecore.Ecommerce.TP"))
                    litStatus.Text += containerRegistration.RegisteredType + "<br />" + containerRegistration.MappedToType + "<br /><br/>";
            }
        }
    }
}