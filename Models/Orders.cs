using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportShop.Models
{
    public class Orders
    {
        public  string order_date { get; set; }
        public long  order_number { get; set; }
        public long Item_Number { get; set; }
        public long Customer_Number { get; set; }

      
    }
}