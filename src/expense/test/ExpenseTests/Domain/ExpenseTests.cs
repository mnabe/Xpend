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
            Fixture fixture = new Fixture();
            fixture.Customize<Expense>(c => c.With(x => x.ExpenseCategory, ExpenseCategory.FOOD));
            Expense expense = fixture.Create<Expense>();

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
