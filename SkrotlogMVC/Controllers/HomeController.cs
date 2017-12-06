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

        [Route("Contract/{id:int}")]
        [Route("Kontrakt/{id:int}")]
        public IActionResult ContractDetails(int id)
        {
            return View(repositories.ContractCollection.Find(x => x.Id == id));
        }

        [HttpPost]
        [Route("Contract/{id:int}")]
        [Route("Kontrakt/{id:int}")]
        public IActionResult ContractDetails(int id, int lineNumber, int amount)
        {
            return View(repositories.ContractCollection.Find(x => x.Id == id));
        }

        [Route("CreateContract")]
        [Route("OpretKontrakt")]
        public IActionResult CreateContract()
        {
            return View(repositories);
        }

        [HttpPost]
        [Route("CreateContract")]
        [Route("OpretKontrakt")]
        public IActionResult CreateContract(string customer, string currency, string[][] contractLineArray)
        {
            repositories.AddContract(customer, currency, contractLineArray);

            return View(repositories);
        }

        [HttpPost]
        [Route("CreateCustomer")]
        [Route("OpretOpkøber")]
        public IActionResult CreateCustomer(string customer, string country)
        {
            if (!string.IsNullOrWhiteSpace(customer) && !string.IsNullOrWhiteSpace(country))
                repositories.AddCustomer(customer, country);

            return View(repositories.CustomerCollection);
        }

        [Route("CreateCustomer")]
        [Route("OpretOpkøber")]
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