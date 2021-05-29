using expense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.ports.incoming
{
    public class EditExpenseCommand
    {
        public int ExpenseId { get; set; }
        public string ExpenseCategory { get; set; }
        public decimal ExpenseCost { get; set; }
        public EditExpenseCommand(int expenseId, string expenseCategory, decimal expenseCost)
        {
            ExpenseId = expenseId;
            ExpenseCategory = expenseCategory;
            ExpenseCost = expenseCost;
        }
    }
}
