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
            TestFixture _testFixture = new TestFixture();
            _testFixture.Fixture.Customize(new AutoMoqCustomization());
            _testFixture.Fixture.Customize<CreateExpenseCommand>(c => c.With(x => x.ExpenseCategory, "HOTEL"));
            CreateExpenseCommand command = _testFixture.Fixture.Create<CreateExpenseCommand>();
            CreateExpenseService service = _testFixture.Fixture.Create<CreateExpenseService>();
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
