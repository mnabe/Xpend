using expense.Domain.Enums;
using System;

namespace expense.Application.services.Shared
{
    public class ExpenseCategoryService
    {
        public ExpenseCategory checkValidCategoryEnum(string expenseCategoryString)
        {
            ExpenseCategory expenseCategory = (ExpenseCategory)Enum.Parse(typeof(ExpenseCategory), expenseCategoryString);
            return expenseCategory;
        }
    }
}