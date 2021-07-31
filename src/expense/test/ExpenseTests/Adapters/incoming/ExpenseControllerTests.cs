using AutoFixture;
using expense.Application.ports.incoming;
using expense.Domain.Entities;
using expense.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ExpenseTests.Adapters.incoming
{
    public class ExpenseControllerTests
    {
        private TestFixture _fixture;
        public ExpenseControllerTests()
        {
            _fixture = new TestFixture();
        }
        [Fact]
        public async Task GetExpense_Success()
        {
            //Arrange
            var service = _fixture.Fixture.Freeze<Mock<IGetExpense>>();
            var expense = _fixture.Fixture.Build<Expense>().With(c => c.ExpenseId, 1).Create();
            service.Setup(a => a.GetExpense(1)).ReturnsAsync(expense);
            var expenseController = _fixture.Fixture.Build<ExpenseController>().OmitAutoProperties().Create();

            //Act
            var result = await expenseController.GetExpense(1);

            //Assert
            ObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetExpenses_Success()
        {
            //Arrange
            var service = _fixture.Fixture.Freeze<Mock<IGetExpenses>>();
            var expenses = _fixture.Fixture.Create<IEnumerable<Expense>>();
            service.Setup(a => a.GetExpenses()).ReturnsAsync(expenses);
            var expenseController = _fixture.Fixture.Build<ExpenseController>().OmitAutoProperties().Create();

            //Act
            var result = await expenseController.GetExpenses();

            //Assert
            ObjectResult objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task CreateExpense_Success()
        {
            //Arrange
            var expenseController = _fixture.Fixture.Build<ExpenseController>().OmitAutoProperties().Create();
            string expenseCategory = "HOTEL";
            decimal expenseCost = 700;

            //Act
            var result = await expenseController.CreateExpense(expenseCategory, expenseCost);

            //Assert
            result.Should().BeOfType<CreatedAtActionResult>();
        }
    }
}