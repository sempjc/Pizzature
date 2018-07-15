using System;
using System.Collections.Generic;

namespace Webapp.DataAccess
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public decimal? Sale { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
