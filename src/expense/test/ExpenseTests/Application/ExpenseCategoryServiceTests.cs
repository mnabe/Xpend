using AutoFixture;
using AutoFixture.AutoMoq;
using expense.Application.ports.incoming;
using expense.Application.services.Shared;
using expense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
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
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            ExpenseCategoryService service = fixture.Create<ExpenseCategoryService>();
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
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            ExpenseCategoryService service = fixture.Create<ExpenseCategoryService>();
            string expenseCategoryString = "INVALID CATEGORY";

            //Act
            Action act = () => service.checkValidCategoryEnum(expenseCategoryString);

            //Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
