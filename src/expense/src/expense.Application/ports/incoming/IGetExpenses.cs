using expense.Domain.Entities;
using System.Collections.Generic;

namespace expense.Application.ports.incoming
{
    public interface IGetExpenses
    {
        public List<Expense> GetExpenses();
    }
}
