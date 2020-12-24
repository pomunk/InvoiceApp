using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using DAL;
using Microsoft.Extensions.Logging;

namespace InvoiceApp.Models
{
    public class OrderManager : IOrderManager
    {
        private IDataAccess dal;
        private ILogger logger;
        private List<Orders> _orders = new List<Orders>();

        public OrderManager(IDataAccess dal, ILogger<OrderManager> logger)
        {
            this.dal = dal;
            this.logger = logger;
        }

        private List<Orders> GetOrders()
        {
            var serializer = new XmlSerializer(typeof(Orders));
            List<Orders> result = new List<Orders>();
            try
            {
                var orders = this.dal.GetOrders();
                foreach (var order in orders)
                {
                    using (TextReader reader = new StreamReader(order, Encoding.UTF8))
                    {
                        result.Add((Orders) serializer.Deserialize(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return result;
        }

        public SortedDictionary<string, TradingPartner> GetPartnersList()
        {
            var orders = GetOrders();
            var list = new SortedDictionary<string, TradingPartner>();
            foreach (var order in orders)
            {
                foreach (var orderType in order.Order)
                {
                    if (list.ContainsKey(orderType.Header.OrderHeader.TradingPartnerId))
                    {
                        list[orderType.Header.OrderHeader.TradingPartnerId].Orders.Add(orderType);
                    }
                    else
                    {
                        list.Add(orderType.Header.OrderHeader.TradingPartnerId, new TradingPartner(orderType.Header.OrderHeader.TradingPartnerId, new List<OrderType>(){orderType}));
                    }
                }
            }

            return list;
        }

        public TradingPartner GetTradingPartner(string id)
        {
            var partners = GetPartnersList();

            return partners[id];
        }
    }
}