using AutoFixture;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;
using expense.Domain.Enums;

namespace ExpenseTests.Adapters.outgoing
{
    public class ExpensePersistenceTests: IClassFixture<TestFixture>
    {
        private TestFixture _fixture;
        public ExpensePersistenceTests()
        {
            _fixture = new TestFixture();
        }
        [Fact]
        public async Task GetExpenseFromDb_Success()
        {
            //Arrange
            _fixture.Fixture.Customize<Expense>(c => c.With(x => x.ExpenseId, 1));
            Expense expense = _fixture.Fixture.Create<Expense>();

            var mock = new Mock<IFindExpense>();
            mock.Setup(foo => foo.Find(1)).ReturnsAsync(expense);
            IFindExpense repository = mock.Object;

            //Act
            var response = await repository.Find(1);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(1, response.ExpenseId);
        }

        [Fact]
        public async Task GetExpensesFromDb_Success()
        {
            //Arrange
            var expenses = _fixture.Fixture.Create<IEnumerable<Expense>>();

            var mock = new Mock<IFindExpenses>();
            mock.Setup(foo => foo.Find()).ReturnsAsync(expenses);
            IFindExpenses repository = mock.Object;

            //Act
            var response = await repository.Find();

            //Assert
            Assert.Equal(expenses.Count(), response.Count());
        }

        [Fact]
        public async Task ExpenseAddedToDb_Success()
        {
            //Arrange
            Expense expense = _fixture.Fixture.Create<Expense>();

            var mock = new Mock<IAddExpense>();
            mock.Setup(foo => foo.Add(ExpenseCategory.HOTEL, 200)).ReturnsAsync(expense);
            IAddExpense repository = mock.Object;

            //Act
            var response = await repository.Add(ExpenseCategory.HOTEL, 200);

            //Assert
            Assert.IsType<Expense>(response);
        }
    }
}