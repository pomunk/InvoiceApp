using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DAL
{
    //Had this been a real program, we would have put db access in here
    public class DataAccess: IDataAccess
    {
        private string dir = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath, "Orders");
        
        public List<string> GetOrders()
        {
            return Directory.GetFiles(dir, "*.xml").ToList();
        }
    }
}
