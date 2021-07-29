using expense.Domain.Entities;
using System.Threading.Tasks;

namespace expense.Application.ports.incoming
{
    public interface IEditExpense
    {
        public Task<Expense> EditExpense(EditExpenseCommand command);
    }
}
