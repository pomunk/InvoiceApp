using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.Models
{
    public class TradingPartner
    {
        public TradingPartner(string id, List<OrderType> orders)
        {
            this.Id = id;
            this.Orders = orders;
        }
        public string Id { get; set; }
        public List<OrderType> Orders { get; set; }

        public Decimal Total
        {
            get { return Orders.Sum(x => x.Summary.TotalAmount); }
        }

        public int NumLineItems
        {
            get { return Orders.Sum(x => x.Summary.TotalLineItemNumber); }
        }

        public SortedDictionary<string, List<OrderTypeLineItem>> PurchaseOrders
        {
            get
            {
                SortedDictionary<string, List<OrderTypeLineItem>>  list = new SortedDictionary<string, List<OrderTypeLineItem>> ();
                foreach (var order in Orders)
                {
                    if (list.ContainsKey(order.Header.OrderHeader.PurchaseOrderNumber))
                    {
                        list[order.Header.OrderHeader.PurchaseOrderNumber].AddRange(order.LineItem);
                    }
                    else
                    {
                        list.Add(order.Header.OrderHeader.PurchaseOrderNumber, new List<OrderTypeLineItem>(order.LineItem));
                    }
                }
                return list;
            }
        }
        public List<OrderTypeHeaderAddress> Addresses
        {
            //If this was a db, addresses would not be duplicated.
            get
            {
                List<OrderTypeHeaderAddress> addrs = new List<OrderTypeHeaderAddress>();
                var list = Orders.Select(o => o.Header.Address).ToArray();
                foreach(var a in list)
                    addrs.AddRange(a);
                return addrs;
            }
        }
    }
}