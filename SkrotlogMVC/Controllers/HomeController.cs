using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkrotlogMVC.Models.BL;
using SkrotlogMVC.Models;

namespace SkrotlogMVC.Controllers
{
    public class HomeController : Controller
    {
        CustomerRepository customerRepository;

        public HomeController(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("CreateContract")]
        public IActionResult CreateContract()
        {
            return View(customerRepository.CustomerCollection);
        }

        [HttpPost]
        [Route("CreateContract")]
        public IActionResult CreateContract(string customer, string currency, string[][] contractLineArray)
        {
            return View(customerRepository.CustomerCollection);
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public IActionResult CreateCustomer(string customer, string country)
        {
            if (!string.IsNullOrWhiteSpace(customer) && !string.IsNullOrWhiteSpace(country))
                customerRepository.AddCustomer(customer, country);

            return View(customerRepository.CustomerCollection);
        }

        [Route("CreateCustomer")]
        public IActionResult CreateCustomer()
        {
            return View(customerRepository.CustomerCollection);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
