using expense.Domain.Entities;
using expense.Domain.Enums;
using System.Threading.Tasks;

namespace expense.Application.ports.outgoing
{
    public interface IAddExpense
    {
        public Task<Expense> Add(ExpenseCategory expenseCategory, decimal expenseCost);
    }
}
