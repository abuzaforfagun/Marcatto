using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marcatto.Repository
{
    public interface IUnitOfWork
    {
        IBankRepository BankRepository { get; set; }

        Task DoneAsync();
    }
}
