using FluentValidation;

namespace expense.Application.ports.incoming.Validators
{
    public class CreateExpenseValidator: AbstractValidator<CreateExpenseCommand>
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