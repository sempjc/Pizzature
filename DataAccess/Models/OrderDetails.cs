using System;
using System.Collections.Generic;

namespace Webapp.DataAccess
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
        public Orders Order { get; set; }
    }
}
