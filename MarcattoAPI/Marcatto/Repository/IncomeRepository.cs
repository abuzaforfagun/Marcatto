using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marcatto.Model;
using Marcatto.Preseistance;
using Microsoft.EntityFrameworkCore;

namespace Marcatto.Repository
{
    public class IncomeRepository : IIncomeRepository
    {
        public Income LastAddedObject { get; set; }
        private readonly MarcattoDbContext context;

        public IncomeRepository(MarcattoDbContext context)
        {
            this.context = context;
        }

        public void Add(Income income)
        {
            context.Income.Add(income);
            this.LastAddedObject = income;
        }

        public async Task<IEnumerable<Income>> GetAsync()
        {
            return await context.Income.Include(i=>i.BankAccount).ToListAsync();
        }

        public async Task<IEnumerable<Income>> GetAsync(DateTime date)
        {
            return await context.Income.Include(i => i.BankAccount)
                .Where(i => i.AddedDateTime.Year == date.Year && i.AddedDateTime.Month == date.Month).ToListAsync();
        }

        public async Task<DashboardSummery> GetSummery()
        {
            var cash = await context.Income.Where(i => i.PaymentOptionId == 1).SumAsync(i => i.Amount);
            var banks = await context.Income.Include(i => i.BankAccount).Where(i => i.BankAccountId != null)
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

    public class DashboardSummery
    {
        public double Cash { get; set; }
        public List<BankSummery> Banks { get; set; }

        public double Total
        {
            get { return Cash + Banks.Sum(b => b.Amount); }
        }
    }
    public class BankSummery
    {
        public string Name { get; set; }
        public double Amount { get; set; }
    }
}