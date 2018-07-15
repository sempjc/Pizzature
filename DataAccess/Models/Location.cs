using System;
using System.Collections.Generic;

namespace Webapp.DataAccess
{
    public partial class Location
    {
        public Location()
        {
            Customer = new HashSet<Customer>();
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
