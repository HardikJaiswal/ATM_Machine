using System;
using Practise.Models;

namespace Practise.Service
{
    class MoneyTransporter
    {
        public void TransferMoney(account user,account ben, out string userTrans, out string benTrans,int temp)
        {
                userTrans = (new HistoryWriter()).WriteHistory(-temp, "Debited",user);
                benTrans =  (new HistoryWriter()).WriteHistory(temp, "Credited",ben);
        }
    }
}
