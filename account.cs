using System;


namespace Practise.Models
{
    class account
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
        public string WriteHistory(int amt, string ConditionType)
        {
            string newTransaction = DateTime.Now.ToString() + "\t\t Amount " + ConditionType + "\t\t " +
            "Current bal:" + (this.amount + amt) + "\t Prev bal: " + this.amount + "\n";
            this.transhistory = newTransaction + this.transhistory;
            this.amount += amt;
            return newTransaction;
        }
        
        public void TransferMoney(account ben,out string userTrans,out string benTrans)
        {
            Console.WriteLine("Enter the amount");
            int temp = Convert.ToInt32(Console.ReadLine());
            if (temp > this.amount) { Console.WriteLine("INSUFFICIENT BALANCE");benTrans = "";userTrans = ""; }
            else
            {
                userTrans = this.WriteHistory(-temp, "Debited");
                benTrans = ben.WriteHistory(temp, "Credited");
            }
        }
        public string DepositMoney()
        {
            Console.WriteLine("Enter the amount to be deposited");
            int temp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Current balance: Rs." + this.amount);
            return this.WriteHistory(temp, "Credited");
        }
        public string WithdrawMoney()
        {
            Console.WriteLine("Enter the amount to be Withdrawn");
            int temp = Convert.ToInt32(Console.ReadLine());
            if (temp > this.amount) Console.WriteLine("INSUFFICIENT BALANCE");
            Console.WriteLine("Current balance: Rs." + this.amount);
            return this.WriteHistory(-temp, "Debited");
        }
    }
}
