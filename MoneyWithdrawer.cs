using System;
using Practise.Models;

namespace Practise.Service
{
    class MoneyWithdrawer
    {
        public string WithdrawMoney(int temp,account current)
        {
            Console.WriteLine("Current balance: Rs." + current.amount);
            return (new HistoryWriter()).WriteHistory(-temp, "Debited",current);
        }
    }
}
