using expense.Domain.Entities;
using System.Collections.Generic;

namespace expense.Application.ports.outgoing
{
    public interface IFindExpenses
    {
        List<Expense> Find();
    }
}
