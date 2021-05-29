using expense.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.ports.outgoing
{
    public interface IFindExpenses
    {
        List<Expense> Find();
    }
}
