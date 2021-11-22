using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportShop.Models
{
    public class Item
    {
        public string Item_Name { get; set; }
        public long Item_Number { get; set; }
        public string Item_value { get; set; }
        public string Color { get; set; }
        public long Size { get; set; }
    }
}