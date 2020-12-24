using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Models
{
    public interface IOrderManager
    {
        SortedDictionary<string, TradingPartner> GetPartnersList();
        TradingPartner GetTradingPartner(string id);
    }
}
