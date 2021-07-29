using expense.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace expense.Application.ports.outgoing
{
    public interface IFindExpenses
    {
        public Task<IEnumerable<Expense>> Find();
    }
}
