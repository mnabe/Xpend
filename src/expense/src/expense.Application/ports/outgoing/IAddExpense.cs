using expense.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.ports.outgoing
{
    public interface IAddExpense
    {
        Expense Add(string expenseCategory, decimal expenseCost);
    }
}
