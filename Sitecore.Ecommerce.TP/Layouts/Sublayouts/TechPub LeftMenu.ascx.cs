using System.Text;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace Sitecore.Ecommerce.TP.Layouts.Sublayouts
{
    using System;

    public partial class TechPub_LeftMenu : System.Web.UI.UserControl
    {
        private StringBuilder _sb;
        private void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            
            _sb = new StringBuilder();

            var homePath = Sitecore.Context.Site.ContentStartPath + Sitecore.Context.Site.StartItem;
            var homeItem = Sitecore.Context.Database.GetItem(homePath);

            RenderChildren(homeItem);

            litLeftMenu.Text = String.Format("<ul>{0}</ul>", _sb);
        }

        private void RenderChildren(Item currentItem)
        {
            if (currentItem["show in menu"].Equals("1"))
            {
                ChildList children = currentItem.GetChildren();
                
                _sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li><ul>", Links.LinkManager.GetItemUrl(currentItem),
                                FieldRenderer.Render(currentItem, "title"));

                foreach (Item child in children)
                {
                    RenderChildren(child);
                }

                _sb.Append("</ul>");
            }
        }
    }
}