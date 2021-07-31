using AutoFixture;
using AutoFixture.AutoMoq;
using expense.Application.ports.incoming;
using expense.Application.services;
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
            CreateExpenseCommand command = _fixture.Fixture.Create<CreateExpenseCommand>();
            var mock = new Mock<ICreateExpense>();
            mock.Setup(foo => foo.CreateExpense(command)).ReturnsAsync(true);
            ICreateExpense service = mock.Object;

            //Act
            bool success = await service.CreateExpense(command);

            //Assert
            Assert.True(success);
        }
    }
}
