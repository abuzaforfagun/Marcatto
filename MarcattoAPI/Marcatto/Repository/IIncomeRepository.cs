using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marcatto.Model;

namespace Marcatto.Repository
{
    public interface IIncomeRepository
    {
        Income LastAddedObject { get; set; }
        void Add(Income income);
        Task<IEnumerable<Income>> GetAsync();
        Task<IEnumerable<Income>> GetAsync(DateTime date);

        Task<DashboardSummery> GetCurrentMonthSummery();
        Task<double> GetTotalCashAsync();
        Task<double> GetTotalBankAsync();
    }
}
