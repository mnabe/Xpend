using AutoFixture;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using expense.Persistence;
using System.Threading.Tasks;
using Moq;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;

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
        public void ExpenseAddedToDb_Success()
        {
            //Arrange
            _fixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 4));
            ExpenseEntity expense = _fixture.Fixture.Create<ExpenseEntity>();

            //Act
            _fixture.ExpenseDataContext.Expenses.Add(expense);
            _fixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(1, _fixture.ExpenseDataContext.Expenses.Count());
            _fixture.ExpenseDataContext.ChangeTracker.Clear();
        }

        [Fact]
        public void ExpenseUpdated_Success()
        {
            //Arrange
            _fixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 5));
            ExpenseEntity expense = _fixture.Fixture.Create<ExpenseEntity>();
            _fixture.ExpenseDataContext.Expenses.Add(expense);
            _fixture.ExpenseDataContext.SaveChanges();

            //Act
            ExpenseEntity entity = _fixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 5).FirstOrDefault();
            entity.ExpenseCost = 200;
            _fixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(200, _fixture.ExpenseDataContext.Expenses.FirstOrDefault().ExpenseCost);
            _fixture.ExpenseDataContext.ChangeTracker.Clear();
        }
    }
}