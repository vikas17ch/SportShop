using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportShop.Models
{
    public class Customer
    {
        public string Customer_Name { get; set; }
        public long Customer_Number { get; set; }
        public long Contact_Number { get; set; }
        public string Address { get; set; }
        public  string Email_Id { get; set; }
    }
}