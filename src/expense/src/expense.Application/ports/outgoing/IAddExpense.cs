using expense.Domain.Entities;
using expense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.ports.outgoing
{
    public interface IAddExpense
    {
        Expense Add(ExpenseCategory expenseCategory, decimal expenseCost);
    }
}
