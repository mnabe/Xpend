using expense.Domain.Enums;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ExpenseTests")]
[assembly: InternalsVisibleTo("expense.WebApi")]

namespace expense.Application.services.Shared
{
    internal class ExpenseCategoryService
    {
        internal ExpenseCategory checkValidCategoryEnum(string expenseCategoryString)
        {
            ExpenseCategory expenseCategory = (ExpenseCategory)Enum.Parse(typeof(ExpenseCategory), expenseCategoryString);
            return expenseCategory;
        }
    }
}