﻿using AutoFixture;
using AutoFixture.AutoMoq;
using expense.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
        public void GetExpense_Success()
        {
            //Arrrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var expenseController = fixture.Build<ExpenseController>().OmitAutoProperties().Create();

            //Act
            var result = expenseController.GetExpense(1);

            //Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        [Fact]
        public void GetExpenses_Success()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var expenseController = fixture.Build<ExpenseController>().OmitAutoProperties().Create();

            //Act
            var result = expenseController.GetExpenses();

            //Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void CreateExpense_Success()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var expenseController = fixture.Build<ExpenseController>().OmitAutoProperties().Create();
            string expenseCategory = "HOTEL";
            decimal expenseCost = 700;

            //Act

            var result = expenseController.CreateExpense(expenseCategory, expenseCost);

            //Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        //[Fact]
        //public void CreateExpense_ThrowsException()
    }
}
