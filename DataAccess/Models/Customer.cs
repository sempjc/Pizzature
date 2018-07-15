using System;
using System.Collections.Generic;

namespace Webapp.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
