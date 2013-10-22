using System;
using System.Web.Script.Services;
using System.Web.Services;
using Sitecore.Ecommerce.DomainModel.Carts;

namespace Sitecore.Ecommerce.TP.Layouts.Sublayouts
{
    /// <summary>
    /// Summary description for MyBasketService
    /// </summary>
    [WebService(Namespace = "http://sitecore.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyBasketService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public void AddToBasket(string productCode)
        {
            var manager = Ecommerce.Context.Entity.Resolve<IShoppingCartManager>();
            
            manager.AddProduct(productCode, 1);
        }

        [WebMethod(EnableSession = true)]
        public string LoadSublayout(string sublayout, string id)
        {
            try
            {
                return Sitecore.Ecommerce.Utils.MainUtil.RenderSublayout(id, sublayout);
            }
            catch (Exception exception2)
            {
                return exception2.ToString();
            }
        }

    }
}
