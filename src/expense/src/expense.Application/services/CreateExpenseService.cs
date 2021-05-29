using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Enums;
using expense.Application.services.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.services
{
    public class CreateExpenseService : ICreateExpense
    {
        private readonly IAddExpense _addExpense;
        public CreateExpenseService(IAddExpense addExpense)
        {
            _addExpense = addExpense;
        }
        public bool CreateExpense(CreateExpenseCommand command)
        {
            ExpenseCategoryService expenseCategoryService = new ExpenseCategoryService();
            ExpenseCategory expenseCategory = expenseCategoryService.checkValidCategoryEnum(command.ExpenseCategory);
            _addExpense.Add(expenseCategory, command.ExpenseCost);
            return true;
        }
    }
}
