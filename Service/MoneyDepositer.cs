using System;
using Practise.Models;

namespace Practise.Service
{
    class MoneyDepositer
    {
        public string DepositMoney(int temp,account current)
        {
            current.amount += temp;
            Console.WriteLine("Current balance: Rs." + current.amount);
            return (new HistoryWriter()).WriteHistory(temp, "Credited",current);
        }
    }
}
