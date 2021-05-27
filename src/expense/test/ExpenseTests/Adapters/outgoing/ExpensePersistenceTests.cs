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
    }
}
