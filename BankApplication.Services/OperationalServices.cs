using System;
using BankApplication.Models;
using System.Collections.Generic;

namespace BankApplication.Services
{
    public class OperationalServices 
    {
        Bank CurrentBank;

        List<Bank> BankList = new List<Bank>();
        public string GetUserAccount(int AccountNumber)
        {
            if (!CurrentBank.AllAccounts.ContainsKey(AccountNumber)) throw new Exception(" Invalid Account Number ");
            return CurrentBank.AllAccounts[AccountNumber].Name;
        }
        public List<string> GetBankList()
        {
            List<string> result = new List<string>();
            foreach(Bank CurrentBank in BankList)
            {
                result.Add(CurrentBank.BankName);
            }
            return result;
        }
        public void AddBank(string BankName)
        {
            BankList.Add(new Bank(BankName));
        }
        public void BankSelection(int Count)
        {
            if (Count > BankList.Count) throw new Exception("No Bank At This Index.");
            CurrentBank = BankList[Count - 1];
        }

        public List<string> GetTransactions(int AccountNumber)
        {
            return CurrentBank.AllAccounts[AccountNumber].Transhistory;
        }

        public int CreateAccount(string UserName)
        {
            int NewAccountNumber;
            
            do
            {
                NewAccountNumber = ((new Random()).Next(0, 100000) %100000) + 100000;
            } while (CurrentBank.AllAccounts.ContainsKey(NewAccountNumber));

            CurrentBank.AllAccounts.Add(NewAccountNumber, new Account(NewAccountNumber,UserName));
            return NewAccountNumber;
        }
        public void MoneyDeposit(int AccountNumber, int MoneyToBeDeposited)
        {
            Account user = CurrentBank.AllAccounts[AccountNumber];
            user.Amount += MoneyToBeDeposited;
            CurrentBank.TransactionList.Add(this.WriteHistory(MoneyToBeDeposited, "Credited", user));
        }
        private string WriteHistory(int Amount, string Message, Account user)
        {
            string ForBank = "\t\t Account: " + user.AccountNumber;
            string newTransaction =  "\t Amount " + Message
                + "\t\t Transaction Amount: Rs." + Amount + "\t\t Current Balance: Rs." + user.Amount;
            user.Transhistory.Add(DateTime.Now.ToString() + newTransaction);
            return DateTime.Now.ToString() + ForBank + newTransaction;
        }
        public void MoneyWithdrawl(int AccountNumber,int MoneyToBeWithdrawl)
        {
            Account user = CurrentBank.AllAccounts[AccountNumber];
            if (user.Amount < MoneyToBeWithdrawl)
            {
                throw new Exception("Account does not have sufficient amount for transaction.");
            }
            user.Amount -= MoneyToBeWithdrawl;
            CurrentBank.TransactionList.Add(this.WriteHistory(MoneyToBeWithdrawl, "Debited", user));
        }
        public void TransferMoney(int SenderAccountNumber,int ReceiverAccountNumber ,int AmountToBeTransffered)
        {
            if (!CurrentBank.AllAccounts.ContainsKey(ReceiverAccountNumber)) 
                throw new Exception("Incorrect Beneficiary Account Number.");
            try
            {
                this.MoneyWithdrawl(SenderAccountNumber, AmountToBeTransffered);
            }
            catch(Exception e)
            {
                throw e;
            }
            this.MoneyDeposit(ReceiverAccountNumber, AmountToBeTransffered);
        }
    }
}
