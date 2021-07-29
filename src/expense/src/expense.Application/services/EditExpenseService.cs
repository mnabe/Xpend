using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Application.services.Shared;
using expense.Domain.Entities;
using expense.Domain.Enums;
using System.Threading.Tasks;

namespace expense.Application.services
{
    internal class EditExpenseService : IEditExpense
    {
        private readonly IUpdateExpense _updateExpense;
        private readonly ExpenseCategoryValidation _expenseCategoryValidation;
        public EditExpenseService(IUpdateExpense updateExpense)
        {
            _updateExpense = updateExpense;
            _expenseCategoryValidation = new ExpenseCategoryValidation();
        }
        public async Task<Expense> EditExpense(EditExpenseCommand command)
        {
            ExpenseCategory expenseCategory = _expenseCategoryValidation.checkValidCategoryEnum(command.ExpenseCategory);
            var response = await _updateExpense.UpdateExpense(command.ExpenseId, expenseCategory, command.ExpenseCost);
            return response;
        }
    }
}
