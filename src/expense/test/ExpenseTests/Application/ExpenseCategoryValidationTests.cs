using AutoFixture;
using AutoFixture.AutoMoq;
using expense.Application.services.Shared;
using expense.Domain.Enums;
using System;
using Xunit;
using FluentAssertions;

namespace ExpenseTests.Application
{
    public class ExpenseCategoryValidationTests
    {
        private Fixture _fixture;
        private DbFixture _dbFixture;
        public ExpenseCategoryValidationTests()
        {
            _fixture = new Fixture();
            _dbFixture = new DbFixture();
        }
        [Fact]
        public void ExpenseCategoryStringIsConvertedToEnum_Success()
        {
            //Arrange
            //TestFixture _testFixture = new TestFixture();
            //_fixture.Customize(new AutoMoqCustomization());
            ExpenseCategoryValidation expenseCategoryValidation = _fixture.Create<ExpenseCategoryValidation>();
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
            TestFixture _testFixture = new TestFixture();
            _testFixture.Fixture.Customize(new AutoMoqCustomization());
            ExpenseCategoryValidation expenseCategoryValidation = _testFixture.Fixture.Create<ExpenseCategoryValidation>();
            string expenseCategoryString = "INVALID CATEGORY";

            //Act
            Action action = () => expenseCategoryValidation.checkValidCategoryEnum(expenseCategoryString);

            //Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}