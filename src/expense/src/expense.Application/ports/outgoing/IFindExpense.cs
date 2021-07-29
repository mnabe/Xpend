using expense.Domain.Entities;
using System.Threading.Tasks;

namespace expense.Application.ports.outgoing
{
    public interface IFindExpense
    {
        public Task<Expense> Find(int id);
    }
}
