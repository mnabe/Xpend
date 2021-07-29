using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace expense.Application.services
{
    internal class GetExpensesService : IGetExpenses
    {
        private readonly IFindExpenses _findExpenses;
        public GetExpensesService(IFindExpenses findExpenses)
        {
            _findExpenses = findExpenses;
        }
        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            IEnumerable<Expense> expenses = await _findExpenses.Find();
            return expenses;
        }
    }
}
