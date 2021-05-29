using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.services
{
    public class GetExpensesService : IGetExpenses
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
