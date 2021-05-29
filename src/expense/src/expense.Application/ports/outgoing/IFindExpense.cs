using expense.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.ports.outgoing
{
    public interface IFindExpense
    {
        Expense Find(int id);
    }
}
