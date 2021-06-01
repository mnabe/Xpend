using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Application.services.Shared;
using expense.Domain.Entities;
using expense.Domain.Enums;

namespace expense.Application.services
{
    internal class EditExpenseService : IEditExpense
    {
        private readonly IUpdateExpense _updateExpense;
        public EditExpenseService(IUpdateExpense updateExpense)
        {
            _updateExpense = updateExpense;
        }
        public Expense EditExpense(EditExpenseCommand command)
        {
            ExpenseCategoryService expenseCategoryService = new ExpenseCategoryService();
            ExpenseCategory expenseCategory = expenseCategoryService.checkValidCategoryEnum(command.ExpenseCategory);
            var response = _updateExpense.UpdateExpense(command.ExpenseId, expenseCategory, command.ExpenseCost);
            return response;
        }
    }
}
