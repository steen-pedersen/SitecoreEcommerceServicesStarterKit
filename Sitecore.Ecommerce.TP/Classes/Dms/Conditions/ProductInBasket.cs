using System.Linq;
using Sitecore.Rules;

namespace Sitecore.Ecommerce.TP.Classes.Dms.Conditions
{
    public class ProductInBasket<T> : Sitecore.Rules.Conditions.WhenCondition<T> where T : RuleContext
    {
        public string ProductCode { get; set; }

        protected override bool Execute(T ruleContext)
        {
            var cart =
                Sitecore.Ecommerce.Context.Entity.GetInstance<Sitecore.Ecommerce.DomainModel.Carts.ShoppingCart>();

            return cart.ShoppingCartLines.Any(line => line.Product.Code.Equals(ProductCode));
        }
    }
}