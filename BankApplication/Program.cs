using System;
using BankApplication.Services;
using System.Collections.Generic;

namespace BankApplication
{
    class Program
    {
        static void Main()
        {
            OperationalServices MyBankService = new OperationalServices();
            while (true)
            {
                Console.WriteLine("\t\tWelcome\nPlease Select Your Bank:");
                int Index = 1;
                foreach (string Banks in MyBankService.GetBankList())
                    Console.WriteLine(Index++ + ". " + Banks);
                Console.Write("Enter your choice: ");
                try
                {
                    MyBankService.BankSelection(Convert.ToInt32(Console.ReadLine()));
                }catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                //Display Menu For All type of user
                MenuForAllUsers();
                AllUsers AllUserMenuChoice = (AllUsers)Enum.Parse(typeof(AllUsers), Console.ReadLine());
                int UserAccountNumber=0;
                string UserName="";
                Boolean ShutDown = false, Again = false ;
                switch (AllUserMenuChoice)
                {
                    case AllUsers.ExistingUser:
                        Console.WriteLine("Enter your Account Number: ");
                        UserAccountNumber = Convert.ToInt32(Console.ReadLine());
                        UserName = MyBankService.GetUserAccount(UserAccountNumber);
                        break;
                    case AllUsers.Newuser:
                        Console.WriteLine("Enter your name for Account Creation: ");
                        UserName = Console.ReadLine();
                        UserAccountNumber = MyBankService.CreateAccount(UserName);
                        break;
                    case AllUsers.ShutDown: ShutDown = true;
                        break;
                    default: Console.WriteLine("Invalid Choice");
                        Again = true;
                        break;
                }
                if (ShutDown) break;
                if (Again) continue;
                while (true)
                {
                    //Menu for types of Services
                    TypesOfServices(UserName, UserAccountNumber);
                    ServiceMenu ServiceMenuChoice = (ServiceMenu)Enum.Parse(typeof(ServiceMenu), Console.ReadLine());
                    try
                    {
                        switch (ServiceMenuChoice)
                        {
                            case ServiceMenu.MoneyDeposit:
                                int AmountOfMoney = GetAmount("Deposit");
                                MyBankService.MoneyDeposit(UserAccountNumber, AmountOfMoney);
                                break;
                            case ServiceMenu.MoneyWithdraw:
                                int WithdrawlMoney = GetAmount("Withdraw");
                                MyBankService.MoneyWithdrawl(UserAccountNumber, WithdrawlMoney);
                                break;
                            case ServiceMenu.TransferMoney:
                                Console.WriteLine("Enter Beneficiary's Account Number");
                                int BeneficiaryAccountNumber = Convert.ToInt32(Console.ReadLine());
                                int AmountToBeTransferred = GetAmount("Transferred");
                                MyBankService.TransferMoney(UserAccountNumber, BeneficiaryAccountNumber, AmountToBeTransferred);

                                break;
                            case ServiceMenu.PrintHistory:
                                int i, Count = 0;
                                List<string> Transactions = MyBankService.GetTransactions(UserAccountNumber);
                                char YesOrNo = 'n';
                                do
                                {
                                    for (i = 0; (i < 5) && (i + Count < Transactions.Count); i++)
                                        Console.WriteLine(Transactions[Transactions.Count - 1 - Count - i]);
                                    Count += i;
                                    if (Count < Transactions.Count)
                                    {
                                        Console.Write("See more previous transactions? y/n  ");
                                        YesOrNo = Console.ReadLine()[0];
                                    }
                                } while (YesOrNo != 'n');
                                break;
                            default:Console.WriteLine("Invalid Choice");
                                Again = true;
                                break;
                        }
                        if (Again)
                        {
                            Again = false;
                            continue;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    Console.WriteLine("Want to use our services again? y/n");
                    char choice = Console.ReadLine()[0];
                    if (choice == 'n')
                    {
                        Console.WriteLine("You have been logged out. Thank you for using our services.");
                        break;
                    }
                }
            }
        }
        enum ServiceMenu
        {
            MoneyDeposit, MoneyWithdraw, TransferMoney, PrintHistory
        }
        enum AllUsers
        {
            ExistingUser, Newuser , ShutDown
        }
        static int GetAmount(string Message)
        {
            Console.Write("Enter the amount you want to " + Message + ": Rs.");
            return Convert.ToInt32(Console.ReadLine());
        }
        static void MenuForAllUsers()
        {
            Console.WriteLine("Welcome to the ATM machine\n Are you a (1) Existing user  (2) New user\n");
            Console.Write("\t\t\t\t\t\t(0) Shut Down the Machine\n\n");
            Console.WriteLine("Enter the choice");
        }
        static  void TypesOfServices(string UserName, int AccountNumber)
        {
            Console.WriteLine("\n\nWelcome " + UserName + "\t\t\tAccount Number:" + AccountNumber);
            Console.WriteLine("What would you like to do:\n 1.Deposit amount\n 2.Withdraw Amount\n 3.Transfer Amount");
            Console.WriteLine(" 4.Print Transaction History\n 5. Log out");
        }
    }
    
}
