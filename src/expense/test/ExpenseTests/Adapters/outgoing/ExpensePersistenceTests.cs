using AutoFixture;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using expense.Persistence;

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
        public void GetExpenseFromDb_Success()
        {
            //Arrange
            _fixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 1));
            ExpenseEntity expense = _fixture.Fixture.Create<ExpenseEntity>();

            //_testFixture.ExpenseDataContext.Expenses.Add(expense);
            _fixture.ExpenseDataContext.Expenses.Add(expense);
            _fixture.ExpenseDataContext.SaveChanges();
            //_testFixture.ExpenseDataContext.SaveChanges();
            
            //Act
            //ExpenseEntity entity = _testFixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 1).FirstOrDefault();
            ExpenseEntity entity = _fixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 1).FirstOrDefault();

            //Assert
            Assert.NotNull(entity);
            Assert.Equal(1, entity.ExpenseId);
        }
        [Fact]
        public void GetExpensesFromDb_Success()
        {
            //Arrange
            _fixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 2));
            ExpenseEntity expenseOne = _fixture.Fixture.Create<ExpenseEntity>();
            _fixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 3));
            ExpenseEntity expenseTwo = _fixture.Fixture.Create<ExpenseEntity>();
            _fixture.ExpenseDataContext.Expenses.Add(expenseOne);
            _fixture.ExpenseDataContext.Expenses.Add(expenseTwo);
            _fixture.ExpenseDataContext.SaveChanges();

            //Act
            IEnumerable<ExpenseEntity> expenses = _fixture.ExpenseDataContext.Expenses.AsEnumerable();

            //Assert
            Assert.Equal(2, expenses.Count());
            _fixture.ExpenseDataContext.ChangeTracker.Clear();
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