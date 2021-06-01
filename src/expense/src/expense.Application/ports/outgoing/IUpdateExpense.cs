using expense.Domain.Entities;
using expense.Domain.Enums;

namespace expense.Application.ports.outgoing
{
    public interface IUpdateExpense
    {
        Expense UpdateExpense(int id, ExpenseCategory expenseCategory, decimal expenseCost);
    }
}
