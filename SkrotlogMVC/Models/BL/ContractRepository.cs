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

        public int Count
        {
            get { return listOfContracts.Count; }
        }

        public ContractRepository()
        {
            listOfContracts = new List<Contract>();
        }

        public void AddContract(Contract contract)
        {
            listOfContracts.Add(contract);
        }

        public void AddContract(Customer customer, DateTime date, Currency currency, string initials)
        {
            Contract c = new Contract(Count, customer, date, currency, initials);
            listOfContracts.Add(c);
        }

        public void AddContract(string customer, string currency, string[][] contractLineArray, List<Material> materials, List<Customer> customers)
        {
            if(IsFormValid(customer, currency, contractLineArray))
            {
                Contract contract = new Contract(customers.Find(x => x.Name == customer), DateTime.Now, Currency.DKK, "AA");

                foreach (string[] contractLine in contractLineArray)
                {
                    ContractLine cl = new ContractLine(materials.Find(x => x.Type == contractLine[0]), decimal.Parse(contractLine[1]), int.Parse(contractLine[2]), contractLine[3]);
                    contract.ContractLines.Add(cl);
                }

                listOfContracts.Add(contract);
            }
        }

        public bool IsFormValid(string customer, string currency, string[][] contractLineArray)
        {
            if (string.IsNullOrWhiteSpace(customer) || string.IsNullOrWhiteSpace(currency))
                return false;

            foreach (string[] contractLine in contractLineArray)
            {
                if (string.IsNullOrWhiteSpace(contractLine[0]) || string.IsNullOrWhiteSpace(contractLine[1]) || string.IsNullOrWhiteSpace(contractLine[2]))
                    return false;
            }

            return true;
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