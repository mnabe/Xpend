using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;

namespace expense.Application.services
{
    internal class GetExpenseService: IGetExpense
    {
        private readonly IFindExpense _findExpense;
        public GetExpenseService(IFindExpense findExpense)
        {
            _findExpense = findExpense;
        }
        public Expense GetExpense(int id)
        {
            Expense expense = _findExpense.Find(id);
            return expense;
        }
    }
}
