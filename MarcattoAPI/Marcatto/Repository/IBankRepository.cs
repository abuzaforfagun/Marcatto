using System.Collections.Generic;
using System.Threading.Tasks;
using Marcatto.Model;

namespace Marcatto.Repository
{
    public interface IBankRepository
    {
        BankAccount LastAddedObject { get; set; }
        void Add(BankAccount account);
        Task<BankAccount> GetAsync(int id);
        Task<IList<BankAccount>> GetAllAsync();
        Task TerminateAsync(BankAccount account);
    }
}
