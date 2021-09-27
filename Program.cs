using System;
using System.Collections.Generic;

namespace Practise
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, account> accounts = new Dictionary<int, account>();
            while (true) {
                iffails:
                Console.WriteLine("Welcome to the ATM machine\n Are you a (1) Existing user  (2) New user\n");
                Console.Write("\t\t\t\t\t\t(0) Shut Down the Machine\n\n");
                Console.WriteLine("Enter the choice");
                int temp = Convert.ToInt16(Console.ReadLine());
                account current;
                if (temp == 2) {
                    do { 
                        temp = (new Random()).Next(0, 100000); 
                    }while (accounts.ContainsKey(temp));
                    current = createAccount(temp);
                    accounts.Add(temp, current);
                }
                else if (temp == 1)
                {
                    Console.WriteLine("Enter the Account number: ");
                    temp = Convert.ToInt32(Console.ReadLine());
                    if (accounts.ContainsKey(temp)) current = accounts[temp];
                    else goto iffails;
                }
                else if (temp == 0)
                {
                    Console.Write("WARNING: ALL DATA WILL BE DELETED, STILL PROCEED? Y/N\n");
                    char ans = Console.ReadLine()[0];
                    if (ans == 'Y' || ans == 'y') break;
                    else goto iffails;
                }
                else
                {
                    Console.WriteLine("invalid choice");
                    goto iffails;
                }
                while (true)
                {
                    bool flag= false;
                    Console.WriteLine("\n\nWelcome back " + current.name +"\t\t Account Number:" + current.accNum);
                    Console.WriteLine("What would you like to do:\n 1.Deposit amount\n 2.Withdraw Amount\n 3.Transfer Amount");
                    Console.WriteLine(" 4.Print Transaction History\n 5. Log out");
                    temp = Convert.ToInt16(Console.ReadLine());
                    switch (temp)
                    {
                        case 1:
                            Console.WriteLine("Enter the amount to be deposited");
                            temp = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Current balance: Rs." + current.amount);
                            current.transhistory = DateTime.Now.ToString() + "\t\tAmount Credited\t\t " +
                             "Current bal:" + (current.amount + temp) + "\t Prev bal: " + current.amount + "\n" + current.transhistory;
                            current.amount += temp;
                            break;
                        case 2:
                            Console.WriteLine("Enter the amount to be Withdrawn");
                            temp = Convert.ToInt32(Console.ReadLine());
                            if (temp > current.amount) Console.WriteLine("INSUFFICIENT BALANCE");
                            else
                            {
                                current.transhistory = DateTime.Now.ToString() + "\t\tAmount Debited\t\t " +
                             "Current bal:" + (current.amount + temp) + "\t Prev bal: " + current.amount + "\n" + current.transhistory;
                                current.amount -= temp;
                            }
                            Console.WriteLine("Current balance: Rs." + current.amount);
                            break;
                        case 3:
                            Console.WriteLine("Enter the beneficiary account number");
                            temp = Convert.ToInt32(Console.ReadLine());
                            if (!accounts.ContainsKey(temp)) Console.WriteLine("Account does not exist");
                            else
                            {
                                account ben = accounts[temp];
                                Console.WriteLine("Enter the amount");
                                temp = Convert.ToInt32(Console.ReadLine());
                                if (temp > current.amount) Console.WriteLine("INSUFFICIENT BALANCE");
                                else
                                {
                                    current.transhistory = DateTime.Now.ToString() + "\t\tAmount debited\t\t " +
                                        "Current bal:" + (current.amount - temp) + "\t Prev bal: " + current.amount + "\n" + current.transhistory;
                                    ben.transhistory = DateTime.Now.ToString() + "\t\tAmount Credited\t\t " +
                                        "Current bal:" +(ben.amount + temp) +"\t Prev bal: " + ben.amount +"\n"+ ben.transhistory;
                                    ben.amount += temp; current.amount -= temp;
                                }
                            }
                            break;
                        case 4: Console.WriteLine(current.transhistory);
                            break;
                        case 5: flag = true;
                            break;
                        default: Console.WriteLine("INVALID INPUT");
                            break;
                    }
                    if (flag) break;
                }
            }
        }
         static account createAccount(int temp)
         {
            Console.WriteLine("Please Enter your name for account creation\n");
            return new account(temp, Console.ReadLine());
         }
    }
    struct account
    {
        public int accNum,amount;
        public string name;
        public string transhistory;
        public account(int t1, string t2)
        {
            accNum = t1; name = t2;
            transhistory = DateTime.Now.ToString() + "\t\tAccount Created\t\t Current bal: Rs.0\t Prev bal: Rs.0\n";
            amount = 0;
        }
    }
}
