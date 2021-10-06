using System.Collections.Generic;

namespace Practise.Models
{
    public class Bank
    {
        public Dictionary<int, account> AllAccounts = new Dictionary<int, account>();

        public string BankName, TypeOfBank,TransactionList;
    }
}