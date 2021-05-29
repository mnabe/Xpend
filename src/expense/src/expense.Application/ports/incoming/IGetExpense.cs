using expense.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.ports.incoming
{
    public interface IGetExpense
    {
        Expense GetExpense(int id);
    }
}
