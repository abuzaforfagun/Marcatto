using System.Collections.Generic;
using System.Linq;

namespace Marcatto.Model
{
    public class DashboardSummery
    {
        public double Cash { get; set; }
        public List<BankSummery> Banks { get; set; }

        public double Total
        {
            get { return Cash + Banks.Sum(b => b.Amount); }
        }
    }
}
