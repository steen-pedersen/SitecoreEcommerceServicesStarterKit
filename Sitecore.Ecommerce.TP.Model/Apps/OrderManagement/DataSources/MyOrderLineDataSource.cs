using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Diagnostics;
using Sitecore.Ecommerce.Apps.OrderManagement.DataSources;
using Sitecore.Ecommerce.Apps.OrderManagement.Models;
using Sitecore.Ecommerce.Merchant.OrderManagement;
using Sitecore.Ecommerce.OrderManagement.Orders;
using Sitecore.Ecommerce.TP.Model.Apps.OrderManagement.Model;

namespace Sitecore.Ecommerce.TP.Model.Apps.OrderManagement.DataSources
{

    public class MyOrderLineModelDataSourceRepository : DataSourceRepository<OrderLineModel>
    {
        // Fields
        private MerchantOrderManager _orderManager;

        // Methods
        public virtual OrderLineModel Get(string rawQuery)
        {
            Func<OrderLine, bool> func = null;
            Assert.ArgumentNotNull(rawQuery, "rawQuery");
            long alias = long.Parse(rawQuery);
            Order order = OrderManager.GetOrders().FirstOrDefault((o => o.OrderLines.Any((ol => (ol.Alias == alias)))));
            OrderLineModel model = null;
            if (order == null)
            {
                return model;
            }
            if (func == null)
            {
                func = ol => (ol.Alias == alias);
            }
            return order.OrderLines.Where(func).Select(new Func<OrderLine, OrderLineModel>(GetOrderLineModel)).FirstOrDefault();
        }

        private MyOrderLineModel GetOrderLineModel(OrderLine line)
        {
            Assert.ArgumentNotNull(line, "line");
            return new MyOrderLineModel { Alias = line.Alias, Description = line.LineItem.Item.Description, ProductCode = line.LineItem.Item.Code, ProductName = line.LineItem.Item.Name, Quantity = (long)line.LineItem.Quantity, UnitPrice = line.LineItem.Price.PriceAmount.Value, AdditionalInformation = line.LineItem.Item.AdditionalInformation };
        }

        public override IEnumerable<OrderLineModel> SelectEntities(string rawQuery)
        {
            Assert.ArgumentNotNull(rawQuery, "rawQuery");
            Assert.IsNotNull(OrderManager, "Unable to get OrderLines. OrderManager cannot be null.");
            return OrderManager.GetOrder(rawQuery).OrderLines.Select(new Func<OrderLine, OrderLineModel>(GetOrderLineModel));
        }

        // Properties
        public MerchantOrderManager OrderManager
        {
            get
            {
                return (_orderManager ?? (_orderManager = Context.Entity.Resolve<MerchantOrderManager>()));
            }
            set
            {
                Assert.ArgumentNotNull(value, "value");
                _orderManager = value;
            }
        }
    }




}

