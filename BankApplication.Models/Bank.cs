using System.Collections.Generic;

namespace BankApplication.Models
{
    public class Bank
    {
        public Dictionary<int, Account> AllAccounts = new Dictionary<int, Account>();
        public string BankName { get; set; }
        public List<string> TransactionList=new List<string>();

        public Bank(string Name)
        {
            BankName = Name;
            //TransactionList.Add("Date && Time \t\t Account Number \t\t Transaction \t\t Amount");
        }
    }
}