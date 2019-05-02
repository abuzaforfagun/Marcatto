using Marcatto.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marcatto.Repository
{
    public interface IExpenseRepository
    {
        Expense LastAddedObject { get; set; }
        void Add(Expense expense);
        Task<IEnumerable<Expense>> GetAsync();
        Task<IEnumerable<Expense>> GetAsync(DateTime date);
        Task<DashboardSummery> GetSummery();
    }
}
