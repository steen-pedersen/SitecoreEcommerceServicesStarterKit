using Sitecore.Rules;

namespace Sitecore.Ecommerce.TP.Classes.Dms.Conditions
{
    public class ShippingProviderSelected<T> : Sitecore.Rules.Conditions.StringOperatorCondition<T> where T : RuleContext
    {
        public string ShippingProviderCode { get; set; }

        protected override bool Execute(T ruleContext)
        {
            var cart =
                Sitecore.Ecommerce.Context.Entity.GetInstance<Sitecore.Ecommerce.DomainModel.Carts.ShoppingCart>();

            if (cart.ShippingProvider == null)
                return false;

            if (cart.ShippingProvider.Code == null)
                return false;

            return Compare(ShippingProviderCode, cart.ShippingProvider.Code);
        }
    }
}