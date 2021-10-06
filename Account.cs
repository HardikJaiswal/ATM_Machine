using System;

namespace Practise.Models
{
    public class account
    {
        public int accNum, amount;
        public string name;
        public string transhistory;
        public account(int t1, string t2)
        {
            accNum = t1; name = t2;
            transhistory = DateTime.Now.ToString() + "\t\tAccount Created\t\t ";
            amount = 0;
        }
    }
}
