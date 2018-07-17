using System;
using System.Collections.Generic;
using Webapp.DataAccess.Models;

namespace Webapp.UI.Models
{
    public class OrderByLocation
    {
        public IEnumerable<Inventory> InventoryLocation { set; get; }
        public IEnumerable<Item>      Item { set; get; }
        public IEnumerable<ItemType>  Types { set; get; }
        public Orders Orders { get; set; }
        public List<NewOrderDetails> NewOrderDetails { get; set; }
    }
}
