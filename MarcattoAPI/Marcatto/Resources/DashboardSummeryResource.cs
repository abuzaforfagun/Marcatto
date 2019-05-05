using System;
using System.Collections.Generic;
using System.Text;
using Marcatto.Model;

namespace Marcatto.Resources
{
    public class DashboardSummeryResource
    {
        public DashboardSummery Income { get; set; }
        public DashboardSummery Expense { get; set; }
        public double BankBalance { get; set; }
        public double CashBalance { get; set; }
    }
}
