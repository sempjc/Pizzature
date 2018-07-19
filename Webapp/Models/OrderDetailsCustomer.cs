using System;
using System.Collections.Generic;
using Webapp.DataAccess.Models;


namespace Webapp.UI.Models
{
    public class OrderDetailsCustomer
    {
        public List<OrderDetails> OrderDetails { get; set; }
        public List<Item> Item { get; set; }
    }
}
