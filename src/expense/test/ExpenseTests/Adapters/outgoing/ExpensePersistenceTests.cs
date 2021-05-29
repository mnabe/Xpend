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
        DbFixture _DbFixture;
        public ExpensePersistenceTests(DbFixture dbFixture)
        {
            _DbFixture = dbFixture;
        }
        [Fact]
        public void GetExpenseFromDb_Success()
        {
            //Arrange
            Fixture fixture = new Fixture();
            fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 1));
            ExpenseEntity expense = fixture.Create<ExpenseEntity>();
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
            //Arrange
            Fixture fixture = new Fixture();
            ExpenseEntity expenseOne = fixture.Create<ExpenseEntity>();
            ExpenseEntity expenseTwo = fixture.Create<ExpenseEntity>();
            _DbFixture.ExpenseDataContext.Expenses.Add(expenseOne);
            _DbFixture.ExpenseDataContext.Expenses.Add(expenseTwo);
            _DbFixture.ExpenseDataContext.SaveChanges();

            //Act
            IEnumerable<ExpenseEntity> expenses = _DbFixture.ExpenseDataContext.Expenses.AsEnumerable();

            //Assert
            Assert.Equal(2, expenses.Count());
        }

        [Fact]
        public void ExpenseAddedToDb_Success()
        {
            //Arrange
            Fixture fixture = new Fixture();
            ExpenseEntity expense = fixture.Create<ExpenseEntity>();

            //Act
            _DbFixture.ExpenseDataContext.Expenses.Add(expense);
            _DbFixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(1, _DbFixture.ExpenseDataContext.Expenses.Count());
        }

        [Fact]
        public void ExpenseUpdated_Success()
        {
            //Arrange
            Fixture fixture = new Fixture();
            fixture.Customize<ExpenseEntity>(c => c.With(x => x.ExpenseId, 1));
            ExpenseEntity expense = fixture.Create<ExpenseEntity>();
            _DbFixture.ExpenseDataContext.Expenses.Add(expense);
            _DbFixture.ExpenseDataContext.SaveChanges();

            //Act
            //Act
            ExpenseEntity entity = _DbFixture.ExpenseDataContext.Expenses.Where(x => x.ExpenseId == 1).FirstOrDefault();
            entity.ExpenseCost = 200;
            _DbFixture.ExpenseDataContext.SaveChanges();

            //Assert
            Assert.Equal(200, _DbFixture.ExpenseDataContext.Expenses.FirstOrDefault().ExpenseCost);
        }
    }
}
