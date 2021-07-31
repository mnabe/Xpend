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
}