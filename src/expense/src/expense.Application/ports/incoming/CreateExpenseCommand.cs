using FluentValidation;

namespace expense.Application.ports.incoming
{
    public class CreateExpenseCommand
    {
        public string ExpenseCategory { get; set; }
        public decimal ExpenseCost { get; set; }
        public CreateExpenseCommand(string expenseCategory, decimal expenseCost)
        {
            ExpenseCategory = expenseCategory;
            ExpenseCost = expenseCost;
        }
    }

    public class CreateExpenseValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseValidator()
        {
            RuleFor(x => x.ExpenseCategory)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please specify a category");
            RuleFor(x => x.ExpenseCost)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please specify an expensecost");
        }
    }
}