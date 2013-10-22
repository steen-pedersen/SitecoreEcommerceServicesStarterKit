using System;
using Sitecore.Rules;

namespace Sitecore.Ecommerce.TP.Classes.Dms.Conditions
{
    public class BasketTotalExVat<T> : Sitecore.Rules.Conditions.OperatorCondition<T> where T : RuleContext
    {
        public string BasketTotal { get; set; }

        protected override bool Execute(T ruleContext)
        {
            if (String.IsNullOrEmpty(BasketTotal))
                return false;

            decimal value = 0;

            if (!Decimal.TryParse(BasketTotal, out value))
                return false;

            var cart =
                Sitecore.Ecommerce.Context.Entity.GetInstance<Sitecore.Ecommerce.DomainModel.Carts.ShoppingCart>();

            switch (GetOperator())
            {
                case Sitecore.Rules.Conditions.ConditionOperator.Equal:
                    return cart.Totals.TotalPriceExVat == value;
                case Sitecore.Rules.Conditions.ConditionOperator.GreaterThanOrEqual:
                    return cart.Totals.TotalPriceExVat >= value;
                case Sitecore.Rules.Conditions.ConditionOperator.GreaterThan:
                    return cart.Totals.TotalPriceExVat > value; 
                case Sitecore.Rules.Conditions.ConditionOperator.LessThanOrEqual:
                    return cart.Totals.TotalPriceExVat <= value;
                case Sitecore.Rules.Conditions.ConditionOperator.LessThan:
                    return cart.Totals.TotalPriceExVat < value;
                case Sitecore.Rules.Conditions.ConditionOperator.NotEqual:
                    return cart.Totals.TotalPriceExVat != value;
            }
            return false;

        }
    }
}