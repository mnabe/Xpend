﻿using expense.Domain.Entities;
using expense.Domain.Enums;
using System.Threading.Tasks;

namespace expense.Application.ports.outgoing
{
    public interface IUpdateExpense
    {
        public Task<Expense> UpdateExpense(int id, ExpenseCategory expenseCategory, decimal expenseCost);
    }
}
