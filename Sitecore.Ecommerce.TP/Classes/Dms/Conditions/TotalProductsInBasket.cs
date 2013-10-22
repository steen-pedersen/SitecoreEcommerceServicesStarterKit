using Sitecore.Ecommerce.Carts;
using Sitecore.Rules;

namespace Sitecore.Ecommerce.TP.Classes.Dms.Conditions
{
    public class TotalProductsInBasket<T> : Sitecore.Rules.Conditions.IntegerComparisonCondition<T> where T : RuleContext
    {
        public int NumberOfProduct { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Value = NumberOfProduct;

            var cart = Sitecore.Ecommerce.Context.Entity.GetInstance<ShoppingCart>();

            var myCart = cart as TP.Model.Carts.ShoppingCart;

            return Compare(System.Convert.ToInt32(myCart.ProductCount()));
        }
    }
}