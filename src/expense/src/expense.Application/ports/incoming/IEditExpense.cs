using expense.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.ports.incoming
{
    public interface IEditExpense
    {
        Expense EditExpense(EditExpenseCommand command);
    }
}
