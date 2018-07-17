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

namespace Webapp.Controllers
{
    public class HomeController : Controller
    {
        public WebappRepository Repo;
        public HomeController(WebappRepository repo) 
        {
            Repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login( UICustomer customer)
        {
            // Check if email is equal to the Register on DB
            // Check if password is equal to the Registered on DB
            // If equal redirect to Customer DashBoard
            // If not return to Login and show error message
            Customer Rcustomer = Repo.GetCustomerByEmail(customer.Email);

            bool isEqualEmail = (customer.Email == Rcustomer.Email);
            bool isEqualPassword = (customer.Password == Rcustomer.Password);

            ViewData["invalidCredential"] = "";

            if(isEqualEmail && isEqualPassword) 
            {
                return RedirectToAction(
                    "Index", 
                    "Dashboard", 
                    new {id = Rcustomer.Id}
                );
            }
            else 
            {
                ViewData["invalidCredential"] = "User name or password is incorrect";
            }

            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Signup(UICustomer customer)
        {
            Customer Rcustomer = (Customer)customer;
            Repo.AddCustomer(Rcustomer);
            Repo.SaveChange();
            Customer c = Repo.GetCustomerByEmail(Rcustomer.Email);
            var ID = c.Id;

            return RedirectToAction(
                "Index", 
                "Dashboard",
                new { id = ID}
            );
        }

        public IActionResult Notfound()
        {
            ViewData["Message"] = "Page not found.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
