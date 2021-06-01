using expense.Domain.Entities;
using expense.Domain.Enums;

namespace expense.Application.ports.outgoing
{
    public interface IAddExpense
    {
        Expense Add(ExpenseCategory expenseCategory, decimal expenseCost);
    }
}
