using AutoFixture;
using expense.Application.ports.incoming;
using expense.Application.services;
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
            CreateExpenseCommand command = _fixture.Fixture.Build<CreateExpenseCommand>().With(c => c.ExpenseCategory, "HOTEL").Create();
            var createExpenseService = _fixture.Fixture.Build<CreateExpenseService>().OmitAutoProperties().Create();

            //Act
            bool success = await createExpenseService.CreateExpense(command);

            //Assert
            Assert.True(success);
        }
    }
}