using expense.Domain.Entities;
using expense.Domain.Enums;
using Xunit;

namespace ExpenseTests.Domain
{
    public class ExpenseTests
    {
        [Fact]
        public void UpdatesExpense()
        {
            //Arrange
            Expense expense = new Expense(ExpenseCategory.FOOD, 50);

            //Act
            expense.UpdatesExpenseCategory(ExpenseCategory.HOTEL);

            //Assert
            Assert.Equal(ExpenseCategory.HOTEL, expense.ExpenseCategory);
        }
    }
}
