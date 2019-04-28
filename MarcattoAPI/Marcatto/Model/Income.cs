using System;
using System.Collections.Generic;
using System.Text;

namespace Marcatto.Model
{
    public class Income
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public int PaymentOptionId { get; set; }
        public BankAccount BankAccount { get; set; }
        public int? BankAccountId { get; set; }
        public string Description { get; set; }
        public DateTime AddedDateTime { get; set; }


    }
}
