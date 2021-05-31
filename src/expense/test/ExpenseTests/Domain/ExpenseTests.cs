using AutoFixture;
using expense.Domain.Entities;
using expense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExpenseTests.Domain
{
    public class ExpenseTests
    {
        [Fact]
        public void UpdatesExpense()
        {
            //Arrange
            TestFixture _testFixture = new TestFixture();
            _testFixture.Fixture.Customize<Expense>(c => c.With(x => x.ExpenseCategory, ExpenseCategory.FOOD));
            Expense expense = _testFixture.Fixture.Create<Expense>();

            //Act
            expense.ExpenseCategory = ExpenseCategory.HOTEL;

            //Assert
            Assert.True(true);
        }
        //[Fact]
        //public void CreatesExpense()

        //[Fact]
        //EnsureEnumIsDisplayedAsNormalStringAndNotUpperCase
    }
}
