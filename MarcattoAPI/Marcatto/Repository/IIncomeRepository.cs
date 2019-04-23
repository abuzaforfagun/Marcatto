using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marcatto.Model;
using Marcatto.Resources;

namespace Marcatto.Repository
{
    public interface IIncomeRepository
    {
        Income LastAddedObject { get; set; }
        Task AddAsync(Income income);
        Task<IEnumerable<Income>> GetAsync();


    }
}
