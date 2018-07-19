using System;
using System.Collections.Generic;
using Webapp.DataAccess.Models;

namespace Webapp.UI.Models
{
    public class OrderByLocation
    {
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public decimal SalesAmount { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public bool ExceedOrder { get; set; }
        public bool ExceedSales { get; set; }
        public IEnumerable<Inventory> InventoryLocation { set; get; }
        public IEnumerable<Item>      Item { set; get; }
        public IEnumerable<ItemType>  Types { set; get; }
        public Orders Orders { get; set; }
        public List<NewOrderDetails> NewOrderDetails { get; set; }
    }
}
