using System;
using Sitecore.Ecommerce.Data;

namespace Sitecore.Ecommerce.TP.Model.Carts
{
    [Serializable]
    public class ShoppingCartLine : Sitecore.Ecommerce.Carts.ShoppingCartLine
    {
        public override string FriendlyUrl
        {
            get { return ""; }
            set
            {
                base.FriendlyUrl = value;
            }
        }

        public string FormData { get; set; }

    }
}
