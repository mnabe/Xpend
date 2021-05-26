using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.ports.incoming
{
    public interface ICreateExpense
    {
        public bool CreateExpense(CreateExpenseCommand command);
    }
}
