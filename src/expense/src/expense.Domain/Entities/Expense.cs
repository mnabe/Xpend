using expense.Domain.Enums;

namespace expense.Domain.Entities
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public decimal ExpenseCost { get; set; }
        public ExpenseStatus ExpenseStatus { get; set; }
        public Expense(ExpenseCategory expenseCategory, decimal expenseCost, ExpenseStatus expenseStatus = ExpenseStatus.RECEIVED)
        {
            ExpenseCategory = expenseCategory;
            ExpenseCost = expenseCost;
            ExpenseStatus = expenseStatus;
        }
    }
}