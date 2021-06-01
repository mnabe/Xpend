using expense.Domain.Enums;

namespace expense.Persistence
{
    internal class ExpenseEntity
    {
        public int ExpenseId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public decimal ExpenseCost { get; set; }
        public ExpenseStatus ExpenseStatus { get; set; }
    }
}
