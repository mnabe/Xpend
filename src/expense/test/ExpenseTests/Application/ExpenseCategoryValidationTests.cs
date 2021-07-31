using AutoFixture;
using expense.Application.services.Shared;
using expense.Domain.Enums;
using System;
using Xunit;
using FluentAssertions;

namespace ExpenseTests.Application
{
    public class ExpenseCategoryValidationTests
    {
        private TestFixture _fixture;
        public ExpenseCategoryValidationTests()
        {
            _fixture = new TestFixture();
        }
        [Fact]
        public void ExpenseCategoryStringIsConvertedToEnum_Success()
        {
            //Arrange
            ExpenseCategoryValidation expenseCategoryValidation = _fixture.Fixture.Create<ExpenseCategoryValidation>();
            string expenseCategoryString = "HOTEL";

            //Act
            var response = expenseCategoryValidation.checkValidCategoryEnum(expenseCategoryString);

            //Assert
            Assert.Equal(ExpenseCategory.HOTEL, response);
            Assert.NotEqual(expenseCategoryString.GetType(), response.GetType());
        }

        [Fact]
        public void ExpenseCategoryStringIsConvertedToEnum_Fails()
        {
            //Arrange
            ExpenseCategoryValidation expenseCategoryValidation = _fixture.Fixture.Create<ExpenseCategoryValidation>();
            string expenseCategoryString = "INVALID CATEGORY";

            //Act
            Action action = () => expenseCategoryValidation.checkValidCategoryEnum(expenseCategoryString);

            //Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}