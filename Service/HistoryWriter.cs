using System;
using Practise.Models;

namespace Practise.Service
{
    public class HistoryWriter
    {
        public string WriteHistory(int amt, string ConditionType,account current)
        {
            string newTransaction = DateTime.Now.ToString() + "\t\t Amount " + ConditionType + "\t\t " +
            "Current bal:" + (current.amount + amt) + "\t Prev bal: " + current.amount + "\n";
            current.transhistory = newTransaction + current.transhistory;
            current.amount += amt;
            return newTransaction;
        }
    }
}
