using System;
using System.Collections.Generic;

namespace BankApplication.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }

        public string AccountID { get; private set; }

        public List<string> Transhistory;
        public Account(int AccountNumber, string Name)
        {
            this.AccountNumber = AccountNumber;
            this.Name = Name;
            AccountID = $"{Name.Substring(0, 3)}{DateTime.Today}";
            Transhistory = new List<string>
            {
                DateTime.Now.ToString() + "\t\tAccount Created\t\t "
            };
        }
    }
}
