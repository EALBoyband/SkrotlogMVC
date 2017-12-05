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
        private RepositoryFacade repositories;

        public HomeController(RepositoryFacade repositoryFacade)
        {
            repositories = repositoryFacade;
        }

        public IActionResult Index()
        {
            return View(repositories);
        }

        [Route("CreateContract")]
        public IActionResult CreateContract()
        {
            return View(repositories);
        }

        [HttpPost]
        [Route("CreateContract")]
        public IActionResult CreateContract(string customer, string currency, string[][] contractLineArray)
        {
            repositories.AddContract(customer, currency, contractLineArray);

            return View(repositories);
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public IActionResult CreateCustomer(string customer, string country)
        {
            if (!string.IsNullOrWhiteSpace(customer) && !string.IsNullOrWhiteSpace(country))
                repositories.AddCustomer(customer, country);

            return View(repositories.CustomerCollection);
        }

        [Route("CreateCustomer")]
        public IActionResult CreateCustomer()
        {
            return View(repositories.CustomerCollection);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}