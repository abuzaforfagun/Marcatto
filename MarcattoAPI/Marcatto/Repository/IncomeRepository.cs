using System;
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

        public async Task AddAsync(Income income)
        {
            context.Income.Add(income);
            this.LastAddedObject = income;
        }
    }
}
