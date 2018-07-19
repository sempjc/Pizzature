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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webapp.UI.Controllers
{
    public class AdminController : Controller
    {
        public WebappRepository Repo;

        public AdminController(WebappRepository repo)
        {
            Repo = repo;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var Location = (List<Location>)Repo.GetAllLocation();
            var list = new LocationList
            {
                List = Location
            };
            return View(list);
        }

        public IActionResult LocationOrderHistory(int ID)
        {
            var orderList = new LocationOrderList
            {
                List = Repo.GetAllOrdersByLocation(ID),
                CustomerList = (List<Customer>)Repo.GetAllCustomer()
            };
            return View(orderList);
        }


        [HttpGet]
        public IActionResult LocationCustomerHistory(int ID)
        {
            var customerList = new LocationCustomerList
            {
                CustomerList = Repo.GetAllCustomerByLocation(ID),
            };
            return View(customerList);
        }

        [HttpPost]
        public IActionResult LocationCustomerHistory(LocationCustomerList customerList)
        {
            var input = customerList.SearchCustome;
            var result = Repo.SearchCustomerByName(input);

            customerList.CustomerList = result;

            return View(customerList);
        }

        [HttpGet]
        public IActionResult LocationInventory(int id)
        {
            var inventory = Repo.GetInventoryByLocationID(id);
            var items = Repo.GetAllItem();
            var locInventory = new LocationInventory
            {
                InventoryList = (List<Inventory>)inventory,
                ItemInventory = (List<Item>)items
            };

            return View(locInventory);
        }

    }
}
