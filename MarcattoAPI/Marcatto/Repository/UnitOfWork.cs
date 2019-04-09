using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Marcatto.Preseistance;

namespace Marcatto.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarcattoDbContext context;
        public IBankRepository BankRepository { get; set; }
        public IPaymentOptionsRepository PaymentOptionsRepository { get; set; }
        public IIncomeRepository IncomeRepository { get; set; }

        public UnitOfWork(MarcattoDbContext context)
        {
            this.context = context;
            BankRepository = new BankRepository(context);
            PaymentOptionsRepository = new PaymentOptionsRepository(context);
            IncomeRepository = new IncomeRepository(context);
        }

        public async Task DoneAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
