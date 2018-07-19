using System;
using System.Collections.Generic;
using Webapp.DataAccess.Models;
namespace Webapp.UI.Models
{
    public class OrderHistoryCustomer
    {
        public string LocationName { get; set; }
        public List<Orders> OrderHistory { get; set; }
    }
}