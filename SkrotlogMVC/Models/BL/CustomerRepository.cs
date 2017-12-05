using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkrotlogMVC.Models;

namespace SkrotlogMVC.Models.BL
{
    public class CustomerRepository
    {
        private List<Customer> listOfCustomers;

        public List<Customer> CustomerCollection
        {
            get { return listOfCustomers; }
        }

        public int Count
        {
            get { return listOfCustomers.Count; }
        }

        public CustomerRepository()
        {
            listOfCustomers = new List<Customer>();
        }

        public  void AddCustomer(string name, string country)
        {
            Customer c = new Customer(name, country);
            listOfCustomers.Add(c);
        }
    }
}
