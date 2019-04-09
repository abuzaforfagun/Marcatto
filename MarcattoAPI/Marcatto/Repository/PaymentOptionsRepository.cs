using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Marcatto.Model;
using Marcatto.Preseistance;
using Microsoft.EntityFrameworkCore;

namespace Marcatto.Repository
{
    public class PaymentOptionsRepository : IPaymentOptionsRepository
    {
        private readonly MarcattoDbContext context;

        public PaymentOptionsRepository(MarcattoDbContext context)
        {
            this.context = context;
        }
        public async Task<IList<PaymentOption>> GetPaymentOptionsAsync()
        {
            return await context.PaymentOptions.ToListAsync();
        }
    }
}
