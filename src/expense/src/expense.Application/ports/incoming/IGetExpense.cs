using expense.Domain.Entities;

namespace expense.Application.ports.incoming
{
    public interface IGetExpense
    {
        Expense GetExpense(int id);
    }
}
