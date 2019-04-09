using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marcatto.Model;
using Marcatto.Preseistance;
using Microsoft.EntityFrameworkCore;

namespace Marcatto.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly MarcattoDbContext context;
        public BankAccount LastAddedObject { get; set; }

        public BankRepository(MarcattoDbContext context)
        {
            this.context = context;
        }
        public void Add(BankAccount account)
        {
            account.AddedDate = DateTime.Now;
            this.context.BankAccounts.Add(account);
            this.LastAddedObject = account;
        }

        public async Task<BankAccount> GetAsync(int id)
        {
            return await this.context.BankAccounts.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IList<BankAccount>> GetAllAsync()
        {
            return await this.context.BankAccounts.Where(b=> b.IsTerminated == false).ToListAsync();
        }

        public async Task TerminateAsync(BankAccount account)
        {
            var currentAccount = await this.context.BankAccounts.SingleAsync(a => a.Id == account.Id);
            currentAccount.IsTerminated = true;
            currentAccount.TerminatedDate = DateTime.Now;
        }
    }
}
