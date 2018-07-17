using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapp.Models;
using Webapp.UI.Models;
using Webapp.DataAccess.Models;
using Webapp.Library.Repository;

namespace Webapp.UI.Controllers
{
    public class DashboardController : Controller
    {

        public WebappRepository Repo;

        public DashboardController(WebappRepository repo)
        {
            Repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            Customer customer = Repo.GetCustomerByID(id);

            var fullname = $"{customer.FirstName} {customer.LastName}";

            ViewData["Customer Name"] = fullname;
            ViewData["Customer ID"] = customer.Id;

            return View();
        }

        [HttpGet]
        public IActionResult NewOrder(int id)
        {
            // Check the last time customer make an order
            // if time is less than 2hr 
            // Show a message
            // If time is more than 2hr 
            // Allo user to complete order
            Customer customer = Repo.GetCustomerByID(id);

            OrderByLocation newOrder = new OrderByLocation
            {
                InventoryLocation =
                Repo.GetInventoryByLocationID(customer.LocationId),

                Item = Repo.GetAllItem(),

                Types = Repo.GetAllItemType()
            };

            return View(newOrder);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public void NewOrder(OrderByLocation order)
        {
            // Console.WriteLine("Runned");
            // Calculate the total amout
            // If order exceed $500 cancel order 
            // and inform the user

            // Calculate the total items in the orther
            // If total amount of item exceed from 12 
            // Cancel order and inform the user

            //If everythings is okay proceed to complete the order
            int totalItemSelected = 0;
            int totalQTY = 0;
            decimal totalSales = 0;

            order.NewOrderDetails.ForEach(
            Item =>
            {
                Console.WriteLine(Item.ItemPrice);
                Console.WriteLine(Item.ItemID);
                Console.WriteLine(Item.ItemQty);
                Console.WriteLine(Item.ItemCheck);

                if (Item.ItemCheck)
                {
                    totalItemSelected++;
                    totalQTY += Item.ItemQty;
                    totalSales += (Item.ItemPrice * Item.ItemQty);
                }
            }
            );

            Console.WriteLine("Total information of the order");
            Console.WriteLine(totalItemSelected);
            Console.WriteLine(totalQTY);
            Console.WriteLine(totalSales);




        }

    }
}
