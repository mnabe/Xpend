using expense.Domain.Entities;
using System.Threading.Tasks;

namespace expense.Application.ports.incoming
{
    public interface IGetExpense
    {
        Task<Expense> GetExpense(int id);
    }
}
