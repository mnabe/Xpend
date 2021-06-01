using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;
using System.Collections.Generic;

namespace expense.Application.services
{
    internal class GetExpensesService : IGetExpenses
    {
        private readonly IFindExpenses _findExpenses;
        public GetExpensesService(IFindExpenses findExpenses)
        {
            _findExpenses = findExpenses;
        }
        public List<Expense> GetExpenses()
        {
            List<Expense> expenses = _findExpenses.Find();
            return expenses;
        }
    }
}
