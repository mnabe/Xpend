using expense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Persistence
{
    public class ExpenseEntity
    {
        public int ExpenseId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public decimal ExpenseCost { get; set; }
        public ExpenseStatus ExpenseStatus { get; set; }
    }
}
