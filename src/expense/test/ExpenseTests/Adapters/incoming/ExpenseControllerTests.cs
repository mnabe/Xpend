using AutoFixture;
using AutoFixture.AutoMoq;
using expense.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace ExpenseTests.Adapters.incoming
{
    public class ExpenseControllerTests
    {
        [Fact]
        public void CreateExpense_Success()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var expenseController = fixture.Build<ExpenseController>().OmitAutoProperties().Create();
            string expenseCategory = "HOTEL";
            decimal expenseCost = 700;

            //Act
            HttpStatusCode result = (HttpStatusCode)expenseController.CreateExpense(expenseCategory, expenseCost).StatusCode.Value;

            //Assert
            Assert.True(HttpStatusCode.OK.Equals(result));
        }

        //[Fact]
        //public void CreateExpense_ThrowsException()
    }
}
