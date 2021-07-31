using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Enums;
using expense.Application.services.Shared;
using System.Threading.Tasks;
using FluentValidation;
using System;

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
                string errors = "";
                foreach (var failure in validationResults.Errors)
                {
                    errors += failure.PropertyName + " failed validation with Error: " + failure.ErrorMessage + ". ";
                }
                throw new ArgumentException(errors);
            }
            ExpenseCategory expenseCategory = _expenseCategoryValidation.checkValidCategoryEnum(command.ExpenseCategory);
            await _addExpense.Add(expenseCategory, command.ExpenseCost);
            return true;
        }
    }
}
