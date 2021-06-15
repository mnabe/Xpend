using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;
using System.Threading.Tasks;

namespace expense.Application.services
{
    internal class GetExpenseService: IGetExpense
    {
        private readonly IFindExpense _findExpense;
        public GetExpenseService(IFindExpense findExpense)
        {
            _findExpense = findExpense;
        }
        public async Task<Expense> GetExpense(int id)
        {
            Expense expense = await _findExpense.Find(id);
            return expense;
        }
    }
}
