using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkrotlogMVC.Models.BL
{
    public class RepositoryFacade
    {
        private ContractRepository contractRepository;
        private CustomerRepository customerRepository;

        public List<Customer> CustomerCollection
        {
            get { return customerRepository.CustomerCollection; }
        }

        public List<Material> MaterialCollection
        {
            get
            {
                return new List<Material>()
                {
                    new Material("Aluminium", "A"),
                    new Material("Jern", "J"),
                    new Material("Kobber", "K"),
                    new Material("Messing", "M"),
                    new Material("Zink", "Z")
                };
            }
        }

        public List<Contract> ContractCollection
        {
            get { return contractRepository.GetContracts(); }
        }

        public RepositoryFacade()
        {
            customerRepository = new CustomerRepository();
            contractRepository = new ContractRepository();

            // TEST DATA
            customerRepository.AddCustomer("Something A/S", "Danmark");
            customerRepository.AddCustomer("Another A/S", "Tyskland");
            customerRepository.AddCustomer("AndAnother Aps", "Danmark");
            customerRepository.AddCustomer("Torben's Stål", "Fyn");
            customerRepository.AddCustomer("Peter's Pot", "Rusland");

            Contract c = new Contract(0, CustomerCollection.First(), DateTime.Now, Currency.DKK, "MR");
            c.ContractLines.Add(new ContractLine(0, new Material("Jern", "j"), 200, 1000, 0, true, "whatever"));
            c.ContractLines.Add(new ContractLine(0, new Material("Lommeuld", "l"), 50, 200, 0, true, "whatever"));
            c.ContractLines.Add(new ContractLine(0, new Material("Bananer", "b"), 2, 100, 0, true, "whatever"));
            c.ContractLines.Add(new ContractLine(0, new Material("Fort", "f"), 20000, 100000, 0, true, "whatever"));
            contractRepository.AddContract(c);
            c = new Contract(1, CustomerCollection.Last(), DateTime.Now, Currency.EUR, "SH");
            c.ContractLines.Add(new ContractLine(0, new Material("Jern", "j"), 200, 1000, 0, true, "whatever"));
            c.ContractLines.Add(new ContractLine(0, new Material("Lommeuld", "ls"), 50, 200, 0, true, "whatever"));
            c.ContractLines.Add(new ContractLine(0, new Material("Bananer", "b"), 2, 100, 0, true, ""));
            c.ContractLines.Add(new ContractLine(0, new Material("Fort", "f"), 20000, 100000, 0, true, "Der er et fort her!"));
            contractRepository.AddContract(c);
        }

        public void AddCustomer(string customer, string country)
        {
            customerRepository.AddCustomer(customer, country);
        }

        public void AddContract(string customer, string currency, string[][] contractLineArray)
        {
            contractRepository.AddContract(customer, currency, contractLineArray, MaterialCollection, CustomerCollection);
        }
    }
}
