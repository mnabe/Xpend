using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;
using expense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.services
{
    public class EditExpenseService : IEditExpense
    {
        private readonly IUpdateExpense _updateExpense;
        public EditExpenseService(IUpdateExpense updateExpense)
        {
            _updateExpense = updateExpense;
        }
        public Expense EditExpense(EditExpenseCommand command)
        {
            ExpenseCategory expenseCategory = checkValidCategoryEnum(command.ExpenseCategory);
            var response = _updateExpense.UpdateExpense(command.ExpenseId, expenseCategory, command.ExpenseCost);
            return response;
        }

        private ExpenseCategory checkValidCategoryEnum(string expenseCategoryString)
        {
            ExpenseCategory expenseCategory = (ExpenseCategory)Enum.Parse(typeof(ExpenseCategory), expenseCategoryString);
            return expenseCategory;
        }
    }
}
