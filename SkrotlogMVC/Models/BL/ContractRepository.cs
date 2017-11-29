using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkrotlogMVC.Models;

namespace SkrotlogMVC.Models.BL
{
    public class ContractRepository
    {
        private List<Contract> listOfContracts;

        public CustomerRepository CustomerRepositoryRef { get; set; }

        public int Count
        {
            get { return listOfContracts.Count; }
        }

        public ContractRepository()
        {
            listOfContracts = new List<Contract>();

            //TEST
            //Contract c = new Contract(0, CustomerRepositoryRef.CustomerCollection.First(), DateTime.Now, Currency.DKK, "MR");
            //c.ContractLines.Add(new ContractLine(0, new Material("Jern", "j"), 200, 1000, 0, true, "whatever"));
            //c.ContractLines.Add(new ContractLine(0, new Material("Hur", "H"), 50, 200, 0, true, "whatever"));
            //c.ContractLines.Add(new ContractLine(0, new Material("Bananer", "b"), 2, 100, 0, true, "whatever"));
            //c.ContractLines.Add(new ContractLine(0, new Material("Fort", "f"), 20000, 100000, 0, true, "whatever"));
            //listOfContracts.Add(c);
            //c = new Contract(1, CustomerRepositoryRef.CustomerCollection.First(), DateTime.Now, Currency.EUR, "SH");
            //c.ContractLines.Add(new ContractLine(0, new Material("Jern", "j"), 200, 1000, 0, true, "whatever"));
            //c.ContractLines.Add(new ContractLine(0, new Material("Hur", "H"), 50, 200, 0, true, "whatever"));
            //c.ContractLines.Add(new ContractLine(0, new Material("Bananer", "b"), 2, 100, 0, true, ""));
            //c.ContractLines.Add(new ContractLine(0, new Material("Fort", "f"), 20000, 100000, 0, true, "Der er et fort her!"));
            //listOfContracts.Add(c);
        }

        public void AddContract(Customer customer, DateTime date, Currency currency, string initials)
        {
            Contract c = new Contract(Count, customer, date, currency, initials);
            listOfContracts.Add(c);
        }

        public void AddContractLine(int contractId, Material material, decimal price, int amount, string comment)
        {
            ContractLine c = new ContractLine(material, price, amount, comment);
            listOfContracts.Find(x => x.Id == contractId).ContractLines.Add(c);
        }

        public void AddAmount(int contractId, int contractLineId, int amount)
        {
            Contract selectedContract = listOfContracts.Find(x => x.Id == contractId);
            ContractLine selectedContractLine = selectedContract.ContractLines.Find(x => x.Id == contractLineId);
            selectedContractLine.DeliveredAmount += amount;
        }

        public List<Contract> GetCustomerContracts(int customerId)
        {
            return listOfContracts.FindAll(x => x.Customer.Id == customerId);
        }

        public List<Contract> GetCustomerContracts(string name)
        {
            return listOfContracts.FindAll(x => x.Customer.Name.ToLower() == name.ToLower());
        }

        public List<Contract> GetContracts()
        {
            return listOfContracts;
        }

        public void DeactiveContractLine(int contractId, int contractLineId)
        {
            listOfContracts.Find(x => x.Id == contractId).ContractLines.Find(x => x.Id == contractLineId).Active = false;
        }

        public void RemoveContractLine(int contractId, int contractLineId)
        {
            listOfContracts.Find(x => x.Id == contractId).ContractLines.RemoveAll(x => x.Id == contractLineId);
        }

    }
}