using System;

namespace Marcatto.Domain
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public DateTime AddedDate { get; set; }
        public bool  IsTerminated { get; set; }
        public DateTime TerminatedDate { get; set; }
    }
}
