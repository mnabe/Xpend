using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Enums;
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
            ExpenseCategory expenseCategory = checkValidCategoryEnum(command.ExpenseCategory);
            _addExpense.Add(expenseCategory, command.ExpenseCost);
            return true;
        }

        private ExpenseCategory checkValidCategoryEnum(string expenseCategoryString)
        {
            ExpenseCategory expenseCategory = (ExpenseCategory)Enum.Parse(typeof(ExpenseCategory), expenseCategoryString);
            return expenseCategory;
        }
    }
}
