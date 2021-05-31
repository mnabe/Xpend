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
    public class ExpensePersistenceTests: IClassFixture<DbFixture>
    {
        [Fact]
        public void GetExpenseFromDb_Success()
        {
            //Setup
            DbFixture _DbFixture = new DbFixture();

            //Arrange
            _DbFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 1));
            ExpenseEntity expense = _DbFixture.Fixture.Create<ExpenseEntity>();
            _DbFixture.ExpenseDataContext.Expenses.Add(expense);
            _DbFixture.ExpenseDataContext.SaveChanges();

            //Act
            ExpenseEntity entity = _DbFixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 1).FirstOrDefault();

            //Assert
            Assert.NotNull(entity);
            Assert.Equal(1, entity.ExpenseId);
        }
        [Fact]
        public void GetExpensesFromDb_Success()
        {
            //Setup
            DbFixture _DbFixture = new DbFixture();

            //Arrange
            _DbFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 2));
            ExpenseEntity expenseOne = _DbFixture.Fixture.Create<ExpenseEntity>();
            _DbFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 3));
            ExpenseEntity expenseTwo = _DbFixture.Fixture.Create<ExpenseEntity>();
            _DbFixture.ExpenseDataContext.Expenses.Add(expenseOne);
            _DbFixture.ExpenseDataContext.Expenses.Add(expenseTwo);
            _DbFixture.ExpenseDataContext.SaveChanges();

            //Act
            IEnumerable<ExpenseEntity> expenses = _DbFixture.ExpenseDataContext.Expenses.AsEnumerable();

            //Assert
            Assert.Equal(2, expenses.Count());
            _DbFixture.ExpenseDataContext.ChangeTracker.Clear();
        }

        [Fact]
        public void ExpenseAddedToDb_Success()
        {
            //Setup
            DbFixture _DbFixture = new DbFixture();

            //Arrange
            _DbFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 4));
            ExpenseEntity expense = _DbFixture.Fixture.Create<ExpenseEntity>();

            //Act
            _DbFixture.ExpenseDataContext.Expenses.Add(expense);
            _DbFixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(1, _DbFixture.ExpenseDataContext.Expenses.Count());
            _DbFixture.ExpenseDataContext.ChangeTracker.Clear();
        }

        [Fact]
        public void ExpenseUpdated_Success()
        {
            //Setup
            DbFixture _DbFixture = new DbFixture();

            //Arrange
            _DbFixture.Fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 5));
            ExpenseEntity expense = _DbFixture.Fixture.Create<ExpenseEntity>();
            _DbFixture.ExpenseDataContext.Expenses.Add(expense);
            _DbFixture.ExpenseDataContext.SaveChanges();

            //Act
            ExpenseEntity entity = _DbFixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 5).FirstOrDefault();
            entity.ExpenseCost = 200;
            _DbFixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(200, _DbFixture.ExpenseDataContext.Expenses.FirstOrDefault().ExpenseCost);
            _DbFixture.ExpenseDataContext.ChangeTracker.Clear();
        }
    }
}
