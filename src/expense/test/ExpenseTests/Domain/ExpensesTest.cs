using expense.Domain.Entities;
using expense.Domain.Enums;
using Xunit;

namespace ExpenseTests.Domain
{
    public class ExpensesTest
    {
        [Fact]
        public void CreateExpense_Success()
        {
            //Act
            Expense expense = new Expense(ExpenseCategory.HOTEL, 200);

            //Assert
            Assert.Equal("HOTEL", expense.ExpenseCategory.ToString());
        }
    }
}