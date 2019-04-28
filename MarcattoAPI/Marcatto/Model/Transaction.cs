using System;
using System.Collections.Generic;
using System.Text;

namespace Marcatto.Model
{
    public class Transaction
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int BankId  { get; set; }
        public string BankName { get; set; }
        public bool CashPayment => BankId == 0;

    }
}
