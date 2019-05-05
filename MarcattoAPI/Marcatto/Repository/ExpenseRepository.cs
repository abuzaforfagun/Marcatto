using Marcatto.Model;
using Marcatto.Preseistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marcatto.Repository
{

    public class ExpenseRepository : IExpenseRepository
    {
        public Expense LastAddedObject { get; set; }
        private readonly MarcattoDbContext context;

        public ExpenseRepository(MarcattoDbContext context)
        {
            this.context = context;
        }

        public void Add(Expense expense)
        {
            context.Expense.Add(expense);
            this.LastAddedObject = expense;
        }

        public async Task<IEnumerable<Expense>> GetAsync()
        {
            return await context.Expense.Include(i => i.BankAccount).ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetAsync(DateTime date)
        {
            return await context.Expense.Include(i => i.BankAccount)
                .Where(i => i.AddedDateTime.Year == date.Year && i.AddedDateTime.Month == date.Month).ToListAsync();
        }

        public async Task<DashboardSummery> GetCurrentMonthSummery()
        {
            var currentDate = DateTime.Now;
            var query = context.Expense.Where(i =>
                i.Date.Month == currentDate.Month && i.Date.Year == currentDate.Year);
            var cash = await query.Where(i => i.Date.Month == currentDate.Month && i.Date.Year == currentDate.Year).SumAsync(i => i.Amount);
            var banks = await query.Include(i => i.BankAccount).Where(i => i.BankAccountId != null)
                .GroupBy(i => i.BankAccountId).Select(
                    g => new BankSummery()
                    {
                        Name = g.First().BankAccount.Name,
                        Amount = g.Sum(a => a.Amount)
                    }).ToListAsync();
            var summery = new DashboardSummery
            {
                Banks = banks,
                Cash = cash
            };
            return summery;

        }

        public async Task<double> GetTotalCashAsync()
        {
            return await context.Expense.Where(e => e.BankAccountId == null).SumAsync(i => i.Amount);
        }

        public async Task<double> GetTotalBankAsync()
        {
            return await context.Expense.Where(e => e.BankAccountId != null).SumAsync(i => i.Amount);
        }
    }
}
