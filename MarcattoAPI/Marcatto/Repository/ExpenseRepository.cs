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

        public async Task<IEnumerable<Income>> GetAsync(DateTime date)
        {
            return await context.Income.Include(i => i.BankAccount)
                .Where(i => i.AddedDateTime.Year == date.Year && i.AddedDateTime.Month == date.Month).ToListAsync();
        }

        public async Task<DashboardSummery> GetSummery()
        {
            var cash = await context.Expense.Where(i => i.PaymentOptionId == 1).SumAsync(i => i.Amount);
            var banks = await context.Expense.Include(i => i.BankAccount).Where(i => i.BankAccountId != null)
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
    }
}
