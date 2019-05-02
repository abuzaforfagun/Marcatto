using System.Collections.Generic;
using Marcatto.Model;

namespace Marcatto.Resources
{
    public class TransactionResource
    {
        public List<Transaction> Transactions { get; set; }
        public List<string> AvailableColumns { get; set; }

        public TransactionResource()
        {
            AvailableColumns = new List<string>();
            AvailableColumns.AddRange(new string[]{"date", "description", "amount"});
        }
    }
}
