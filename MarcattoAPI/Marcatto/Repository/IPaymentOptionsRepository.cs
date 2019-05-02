using System.Collections.Generic;
using System.Threading.Tasks;
using Marcatto.Model;

namespace Marcatto.Repository
{
    public interface IPaymentOptionsRepository
    {
        Task<IList<PaymentOption>> GetPaymentOptionsAsync();
    }
}