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

        public IActionResult Index(int id)
        {
            var customer = Repo.GetCustomerByID(id);
            var fullname = $"{customer.FirstName} {customer.LastName}";
            ViewData["Customer Name"] = fullname;
            ViewData["Customer ID"] = customer.Id;
            OrderHistoryCustomer orderHistory;

            try {
                var location = Repo.GetLocationByID(customer.LocationId);
                var orders = Repo.GetAllOrdersByCustomer(customer.Id);


                orderHistory = new OrderHistoryCustomer
                {
                    LocationName = location.Name,
                    OrderHistory = orders,
                };
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                orderHistory = new OrderHistoryCustomer();
                return View(orderHistory);
            }

            return View(orderHistory);
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

                Types = Repo.GetAllItemType(),

                CustomerID = customer.Id,

                LocationID = customer.LocationId
            };

            return View(newOrder);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult NewOrder(OrderByLocation order)
        {
            return RedirectToAction(
                "OrderSummary",
                "DashBoard",
                order
            );
        }

        [HttpPost]
        public IActionResult OrderSummary( OrderByLocation order) 
        {
            return View(order);
        }

        [HttpPost]
        public IActionResult OrderSuccess (OrderByLocation order)
        {
            Repo.AddOrders(
                order.LocationID,
                order.CustomerID,
                order.SalesAmount,
                order.Date,
                order.TimeSpan
            );
            Repo.SaveChange();
            var savedOrder = Repo.GetAllOrders().Last();

            order.NewOrderDetails.ForEach(
                detail =>
                {
                    if(detail.ItemCheck)
                    {
                        Repo.AddOrderDetails(
                            savedOrder.Id,
                            detail.ItemID,
                            detail.ItemQty
                        );
                        Repo.SaveChange();
                    }
                }
            );
            return RedirectToAction("Index","Dashboard", new{id=order.CustomerID});
        }


        [HttpGet]
        public IActionResult OrderDetails(int id, int orderid) {
            ViewData["customerID"] = id;
            var orderDetails = Repo.GetOrdersDetailsByOrderID(orderid);
            var item = (List<Item>) Repo.GetAllItem();
            var cutomerOrderDetails = new OrderDetailsCustomer
            {
                OrderDetails = orderDetails,
                Item = item
            };

            return View(cutomerOrderDetails);
        }


      



    }
}
