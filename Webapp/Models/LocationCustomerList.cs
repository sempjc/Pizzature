using System;
using System.Collections.Generic;
using Webapp.DataAccess.Models;

namespace Webapp.UI.Models
{
    public class LocationCustomerList
    {
        public List<Customer> CustomerList { get; set; }
        public string SearchCustome{ get; set; }
    }
}
