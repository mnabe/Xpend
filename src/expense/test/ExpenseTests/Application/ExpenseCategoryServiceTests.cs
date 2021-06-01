using AutoFixture;
using AutoFixture.AutoMoq;
using expense.Application.services.Shared;
using expense.Domain.Enums;
using System;
using Xunit;
using FluentAssertions;

namespace ExpenseTests.Application
{
    public class ExpenseCategoryServiceTests
    {
        [Fact]
        public void ExpenseCategoryStringIsConvertedToEnum_Success()
        {
            //Arrange
            TestFixture _testFixture = new TestFixture();
            _testFixture.Fixture.Customize(new AutoMoqCustomization());
            ExpenseCategoryService service = _testFixture.Fixture.Create<ExpenseCategoryService>();
            string expenseCategoryString = "HOTEL";

            //Act
            var response = service.checkValidCategoryEnum(expenseCategoryString);

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
            ExpenseCategoryService service = _testFixture.Fixture.Create<ExpenseCategoryService>();
            string expenseCategoryString = "INVALID CATEGORY";

            //Act
            Action action = () => service.checkValidCategoryEnum(expenseCategoryString);

            //Assert
            action.Should().Throw<ArgumentException>();
        }
    }
}
