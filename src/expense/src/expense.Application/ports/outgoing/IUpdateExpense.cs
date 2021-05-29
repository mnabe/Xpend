using expense.Domain.Entities;
using expense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.ports.outgoing
{
    public interface IUpdateExpense
    {
        Expense UpdateExpense(int id, ExpenseCategory expenseCategory, decimal expenseCost);
    }
}
