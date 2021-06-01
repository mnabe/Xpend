using expense.Domain.Entities;

namespace expense.Application.ports.incoming
{
    public interface IEditExpense
    {
        Expense EditExpense(EditExpenseCommand command);
    }
}
