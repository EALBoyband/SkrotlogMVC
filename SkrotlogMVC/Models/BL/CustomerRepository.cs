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

            listOfCustomers.Add(new Customer("Something A/S", "Danmark"));
            listOfCustomers.Add(new Customer("Another A/S", "Tyskland"));
            listOfCustomers.Add(new Customer("AndAnother Aps", "Cuntland"));
            listOfCustomers.Add(new Customer("Torben's Stål (Han er hur)", "Fyn"));
            listOfCustomers.Add(new Customer("Peter's Pot", "Rusland"));
        }

        public  void AddCustomer(string name, string country)
        {
            Customer c = new Customer(name, country);
            listOfCustomers.Add(c);
        }
    }
}
