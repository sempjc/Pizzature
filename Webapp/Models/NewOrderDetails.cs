using System;
namespace Webapp.UI.Models
{
    public class NewOrderDetails
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemID { get; set; }
        public int ItemQty { get; set; }
        public bool ItemCheck { get; set; }
    }
}