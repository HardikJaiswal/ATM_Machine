using System.Collections.Generic;

namespace BankApplication.Models
{
    public class Bank
    {
        public Dictionary<int, Account> AllAccounts = new Dictionary<int, Account>();
        public string BankName { get; set; }
        public List<string> TransactionList=new List<string>();
        public string BankID;

        public Bank(string Name)
        {
            BankName = Name;
            BankID = $"{Name.Substring(0, 3)}{System.DateTime.Today}";
            //TransactionList.Add("Date && Time \t\t Account Number \t\t Transaction \t\t Amount");
        }
    }
}
