using expense.Domain.Enums;

namespace expense.Domain.Entities
{
    public class Expense
    {
        public int ExpenseId { get; private set; }
        public ExpenseCategory ExpenseCategory { get; private set; }
        public decimal ExpenseCost { get; private set; }
        public ExpenseStatus ExpenseStatus { get; private set; }
        public Expense(ExpenseCategory expenseCategory, decimal expenseCost, ExpenseStatus expenseStatus = ExpenseStatus.RECEIVED)
        {
            ExpenseCategory = expenseCategory;
            ExpenseCost = expenseCost;
            ExpenseStatus = expenseStatus;
        }
    }
}