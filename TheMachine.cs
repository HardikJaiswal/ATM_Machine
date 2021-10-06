using System;
using Practise.Models;
using Practise.Service;

namespace Practise.CLI
{
    public class TheMachine : Bank
    {
        public TheMachine(string BankName, string TypeOfBank)
        {
            this.TypeOfBank = TypeOfBank;this.BankName = BankName;
        }
        public void StartTheMachine()
        {
            while (true)
            {
            // Machine Menu for all users
            iffails:

                Console.WriteLine("Welcome to the ATM machine\n Are you a (1) Existing user  (2) New user\n");
                Console.Write("\t\t\t\t\t\t(0) Shut Down the Machine\n\n");
                Console.WriteLine("Enter the choice");
                
                int temp = Convert.ToInt16(Console.ReadLine());
                account current;
                
                if (temp == 2)
                {
                    //creating new account
                    do
                    {
                        temp = (new Random()).Next(0, 100000);
                    } while (AllAccounts.ContainsKey(temp));
                    Console.WriteLine("Please Enter your name for account creation\n");
                    current = new account(temp, Console.ReadLine());
                    AllAccounts.Add(temp, current);
                }

                else if (temp == 1)
                {
                    //existing user
                    Console.WriteLine("Enter the Account number: ");
                    temp = Convert.ToInt32(Console.ReadLine());
                    if (AllAccounts.ContainsKey(temp)) current = AllAccounts[temp];
                    else goto iffails;
                }

                else if (temp == 0)
                {
                    //closing the machine
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

                //After the getting the account
                //Menu for user where functions can be used
                while (true)
                {
                    bool flag = false;
                    Console.WriteLine("\n\nWelcome back " + current.name + "\t\t\tAccount Number:" + current.accNum);
                    Console.WriteLine("What would you like to do:\n 1.Deposit amount\n 2.Withdraw Amount\n 3.Transfer Amount");
                    Console.WriteLine(" 4.Print Transaction History\n 5. Log out");
                    temp = Convert.ToInt16(Console.ReadLine());
                    switch (temp)
                    {
                        case 1:
                            //choice of Money Deposit
                            Console.WriteLine("Enter the amount to be deposited");
                            temp = Convert.ToInt32(Console.ReadLine());
                            TransactionList += (new MoneyDepositer()).DepositMoney(temp,current);
                            break;

                        case 2:
                            //choice of money withdrawl
                            Console.WriteLine("Enter the amount to be Withdrawn");
                            temp = Convert.ToInt32(Console.ReadLine());
                            if (temp > current.amount) Console.WriteLine("INSUFFICIENT BALANCE");
                            else TransactionList += (new MoneyWithdrawer()).WithdrawMoney(temp,current);
                            break;

                        case 3:
                            //Choice of transfer money
                            Console.WriteLine("Enter the beneficiary account number");
                            temp = Convert.ToInt32(Console.ReadLine());
                            string benTrans, userTrans;
                            if (!AllAccounts.ContainsKey(temp)) Console.WriteLine("Account does not exist");
                            else
                            {
                                Console.WriteLine("Enter the amount");
                                temp = Convert.ToInt32(Console.ReadLine());
                                if (temp > current.amount)
                                {
                                    Console.WriteLine("INSUFFICIENT BALANCE");
                                    (new MoneyTransporter()).TransferMoney(current, AllAccounts[temp], out userTrans, out benTrans,temp);
                                    TransactionList += userTrans;
                                    TransactionList += benTrans;
                                }
                            }
                            break;

                        case 4:
                            //choice for transaction History
                            Console.WriteLine(current.transhistory);
                            break;
                        case 5:
                            // Closing logging out the user from machine
                            flag = true;
                            break;
                        default:
                            Console.WriteLine("INVALID INPUT");
                            break;
                    }
                    if (flag) break;
                }
            }
        }
        
    }
}
