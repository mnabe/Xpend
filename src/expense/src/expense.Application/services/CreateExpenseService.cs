using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Enums;
using expense.Application.services.Shared;
using System.Threading.Tasks;
using FluentValidation;
using System;
using System.Linq;

namespace expense.Application.services
{
    internal class CreateExpenseService : ICreateExpense
    {
        private readonly IAddExpense _addExpense;
        private readonly IValidator<CreateExpenseCommand> _validator;
        private readonly ExpenseCategoryValidation _expenseCategoryValidation;
        public CreateExpenseService(IAddExpense addExpense, IValidator<CreateExpenseCommand> validator)
        {
            _addExpense = addExpense;
            _validator = validator;
            _expenseCategoryValidation = new ExpenseCategoryValidation();
        }
        public async Task<bool> CreateExpense(CreateExpenseCommand command)
        {
            var validationResults = await _validator.ValidateAsync(command);
            if (!validationResults.IsValid)
            {
                throw new ArgumentException(validationResults.Errors.First().ToString());
            }
            ExpenseCategory expenseCategory = _expenseCategoryValidation.checkValidCategoryEnum(command.ExpenseCategory);
            await _addExpense.Add(expenseCategory, command.ExpenseCost);
            return true;
        }
    }
}
