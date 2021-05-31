using AutoFixture;
using expense.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using expense.Persistence;

namespace ExpenseTests.Adapters.outgoing
{
    public class ExpensePersistenceTests: IClassFixture<TestFixture>
    {
        [Fact]
        public void GetExpenseFromDb_Success()
        {
            //Setup
            TestFixture _testFixture = new TestFixture();

            //Arrange
            _testFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 1));
            ExpenseEntity expense = _testFixture.Fixture.Create<ExpenseEntity>();
            _testFixture.ExpenseDataContext.Expenses.Add(expense);
            _testFixture.ExpenseDataContext.SaveChanges();

            //Act
            ExpenseEntity entity = _testFixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 1).FirstOrDefault();

            //Assert
            Assert.NotNull(entity);
            Assert.Equal(1, entity.ExpenseId);
        }
        [Fact]
        public void GetExpensesFromDb_Success()
        {
            //Setup
            TestFixture _testFixture = new TestFixture();

            //Arrange
            _testFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 2));
            ExpenseEntity expenseOne = _testFixture.Fixture.Create<ExpenseEntity>();
            _testFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 3));
            ExpenseEntity expenseTwo = _testFixture.Fixture.Create<ExpenseEntity>();
            _testFixture.ExpenseDataContext.Expenses.Add(expenseOne);
            _testFixture.ExpenseDataContext.Expenses.Add(expenseTwo);
            _testFixture.ExpenseDataContext.SaveChanges();

            //Act
            IEnumerable<ExpenseEntity> expenses = _testFixture.ExpenseDataContext.Expenses.AsEnumerable();

            //Assert
            Assert.Equal(2, expenses.Count());
            _testFixture.ExpenseDataContext.ChangeTracker.Clear();
        }

        [Fact]
        public void ExpenseAddedToDb_Success()
        {
            //Setup
            TestFixture _testFixture = new TestFixture();

            //Arrange
            _testFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 4));
            ExpenseEntity expense = _testFixture.Fixture.Create<ExpenseEntity>();

            //Act
            _testFixture.ExpenseDataContext.Expenses.Add(expense);
            _testFixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(1, _testFixture.ExpenseDataContext.Expenses.Count());
            _testFixture.ExpenseDataContext.ChangeTracker.Clear();
        }

        [Fact]
        public void ExpenseUpdated_Success()
        {
            //Setup
            TestFixture _testFixture = new TestFixture();

            //Arrange
            _testFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 5));
            ExpenseEntity expense = _testFixture.Fixture.Create<ExpenseEntity>();
            _testFixture.ExpenseDataContext.Expenses.Add(expense);
            _testFixture.ExpenseDataContext.SaveChanges();

            //Act
            ExpenseEntity entity = _testFixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 5).FirstOrDefault();
            entity.ExpenseCost = 200;
            _testFixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(200, _testFixture.ExpenseDataContext.Expenses.FirstOrDefault().ExpenseCost);
            _testFixture.ExpenseDataContext.ChangeTracker.Clear();
        }
    }
}
