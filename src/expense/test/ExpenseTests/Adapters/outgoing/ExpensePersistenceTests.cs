using AutoFixture;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using expense.Persistence;

namespace ExpenseTests.Adapters.outgoing
{
    public class ExpensePersistenceTests: IClassFixture<TestFixture>
    {
        private Fixture _fixture;
        private DbFixture _dbFixture;
        public ExpensePersistenceTests()
        {
            _fixture = new Fixture();
            _dbFixture = new DbFixture();
        }
        [Fact]
        public void GetExpenseFromDb_Success()
        {
            //Arrange
            _fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 1));
            ExpenseEntity expense = _fixture.Create<ExpenseEntity>();

            //_testFixture.ExpenseDataContext.Expenses.Add(expense);
            _dbFixture.ExpenseDataContext.Expenses.Add(expense);
            _dbFixture.ExpenseDataContext.SaveChanges();
            //_testFixture.ExpenseDataContext.SaveChanges();

            //Act
            //ExpenseEntity entity = _testFixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 1).FirstOrDefault();
            ExpenseEntity entity = _dbFixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 1).FirstOrDefault();

            //Assert
            Assert.NotNull(entity);
            Assert.Equal(1, entity.ExpenseId);
        }
        [Fact]
        public void GetExpensesFromDb_Success()
        {
            //Arrange
            _fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 2));
            ExpenseEntity expenseOne = _fixture.Create<ExpenseEntity>();
            _fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 3));
            ExpenseEntity expenseTwo = _fixture.Create<ExpenseEntity>();
            _dbFixture.ExpenseDataContext.Expenses.Add(expenseOne);
            _dbFixture.ExpenseDataContext.Expenses.Add(expenseTwo);
            _dbFixture.ExpenseDataContext.SaveChanges();

            //Act
            IEnumerable<ExpenseEntity> expenses = _dbFixture.ExpenseDataContext.Expenses.AsEnumerable();

            //Assert
            Assert.Equal(2, expenses.Count());
            _dbFixture.ExpenseDataContext.ChangeTracker.Clear();
        }

        [Fact]
        public void ExpenseAddedToDb_Success()
        {
            //Arrange
            _fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 4));
            ExpenseEntity expense = _fixture.Create<ExpenseEntity>();

            //Act
            _dbFixture.ExpenseDataContext.Expenses.Add(expense);
            _dbFixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(1, _dbFixture.ExpenseDataContext.Expenses.Count());
            _dbFixture.ExpenseDataContext.ChangeTracker.Clear();
        }

        [Fact]
        public void ExpenseUpdated_Success()
        {
            //Arrange
            _fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 5));
            ExpenseEntity expense = _fixture.Create<ExpenseEntity>();
            _dbFixture.ExpenseDataContext.Expenses.Add(expense);
            _dbFixture.ExpenseDataContext.SaveChanges();

            //Act
            ExpenseEntity entity = _dbFixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 5).FirstOrDefault();
            entity.ExpenseCost = 200;
            _dbFixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(200, _dbFixture.ExpenseDataContext.Expenses.FirstOrDefault().ExpenseCost);
            _dbFixture.ExpenseDataContext.ChangeTracker.Clear();
        }
    }
}