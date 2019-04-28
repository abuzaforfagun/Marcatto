using System;
using System.Collections.Generic;
using System.Text;

namespace Marcatto.Resources
{
    public class IncomeResource
    {
        public string Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int PaymentOptionId { get; set; }
        public int BankAccountId { get; set; }
    }
}
