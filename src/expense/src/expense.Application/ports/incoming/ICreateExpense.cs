using System.Threading.Tasks;

namespace expense.Application.ports.incoming
{
    public interface ICreateExpense
    {
        public Task<object> CreateExpense(CreateExpenseCommand command);
    }
}
