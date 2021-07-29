using expense.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace expense.Application.ports.incoming
{
    public interface IGetExpenses
    {
        public Task<IEnumerable<Expense>> GetExpenses();
    }
}
