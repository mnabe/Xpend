using AutoFixture;
using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Application.services;
using expense.Domain.Entities;
using expense.Domain.Enums;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ExpenseTests.Application
{
    public class CreateExpenseServiceTests
    {
        private TestFixture _fixture;
        public CreateExpenseServiceTests()
        {
            _fixture = new TestFixture();
        }
        [Fact]
        public async Task CreateExpense_Success()
        {
            //Arrange
            var expense = _fixture.Fixture.Create<Expense>();
            CreateExpenseCommand command = _fixture.Fixture.Build<CreateExpenseCommand>().With(c => c.ExpenseCategory, "HOTEL").Create();
            var validationResults = _fixture.Fixture.Build<ValidationResult>().Create();

            var addMock = new Mock<ICreateExpense>();
            addMock.Setup(x => x.CreateExpense(command)).ReturnsAsync(expense);
            ICreateExpense addService = addMock.Object;

            var validatorMock = new Mock<IValidator<CreateExpenseCommand>>();
            validatorMock.Setup(x => x.Validate(It.IsAny<CreateExpenseCommand>())).Returns(validationResults);

            //Act
            var response = await addService.CreateExpense(command);

            //Assert
            Assert.Equal(typeof(Expense), response.GetType());
        }
    }
}