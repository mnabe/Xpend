using expense.Domain.Entities;
using System.Threading.Tasks;

namespace expense.Application.ports.incoming
{
    public interface IGetExpense
    {
        public Task<Expense> GetExpense(int id);
    }
}
