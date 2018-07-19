using System;
using System.Collections.Generic;
using Webapp.DataAccess.Models;

namespace Webapp.UI.Models
{
    public class LocationOrderList
    {
        public List<Orders> List { get; set; }
        public List<Customer> CustomerList { get; set; }
    }
}
