﻿using System;
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

        public async Task AddAsync(Income income)
        {
            context.Income.Add(income);
            this.LastAddedObject = income;
        }

        public async Task<IEnumerable<Income>> GetAsync()
        {
            return await context.Income.ToListAsync();
        }

        public async Task<IEnumerable<Income>> GetAsync(DateTime date)
        {
            return await context.Income
                .Where(i => i.AddedDateTime.Year == date.Year && i.AddedDateTime.Month == date.Month).ToListAsync();
        }   
    }
}