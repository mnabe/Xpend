using AutoFixture;
using AutoFixture.AutoMoq;
using expense.Application.ports.incoming;
using expense.Application.services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExpenseTests.Application
{
    public class CreateExpenseServiceTests
    {
        [Fact]

        public void CreateExpense_Success()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Customize<CreateExpenseCommand>(c => c.With(x => x.ExpenseCategory, "HOTEL"));
            CreateExpenseCommand command = fixture.Create<CreateExpenseCommand>();
            CreateExpenseService service = fixture.Create<CreateExpenseService>();
            bool success;

            //Act
            success = service.CreateExpense(command);

            //Assert
            Assert.True(success);
        }

        //public void CreateExpense_ThrowsException()
        //{
            //Use FluentAssertions
        //}
    }
}
