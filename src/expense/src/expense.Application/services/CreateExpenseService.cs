using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Application.services
{
    class CreateExpenseService : ICreateExpense
    {
        private readonly IAddExpense _addExpense;
        public CreateExpenseService(IAddExpense addExpense)
        {
            _addExpense = addExpense;
        }
        public bool CreateExpense(CreateExpenseCommand command)
        {
            
            
        }
    }
}
