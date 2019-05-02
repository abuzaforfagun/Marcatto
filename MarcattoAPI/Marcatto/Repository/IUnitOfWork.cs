using System.Threading.Tasks;

namespace Marcatto.Repository
{
    public interface IUnitOfWork
    {
        IBankRepository BankRepository { get; set; }
        IPaymentOptionsRepository PaymentOptionsRepository { get; set; }

        IIncomeRepository IncomeRepository { get; set; }

        Task DoneAsync();
    }
}
