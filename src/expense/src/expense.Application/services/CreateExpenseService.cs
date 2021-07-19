using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Enums;
using expense.Application.services.Shared;

namespace expense.Application.services
{
    internal class CreateExpenseService : ICreateExpense
    {
        private readonly IAddExpense _addExpense;
        private readonly ExpenseCategoryValidation _expenseCategoryValidation;
        public CreateExpenseService(IAddExpense addExpense)
        {
            _addExpense = addExpense;
            _expenseCategoryValidation = new ExpenseCategoryValidation();
        }
        public bool CreateExpense(CreateExpenseCommand command)
        {
            ExpenseCategory expenseCategory = _expenseCategoryValidation.checkValidCategoryEnum(command.ExpenseCategory);
            _addExpense.Add(expenseCategory, command.ExpenseCost);
            return true;
        }
    }
}
