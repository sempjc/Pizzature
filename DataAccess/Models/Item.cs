using System;
using System.Collections.Generic;

namespace Webapp.DataAccess.Models
{
    public partial class Item
    {
        public Item()
        {
            Inventory = new HashSet<Inventory>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int ItemTypeId { get; set; }

        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
