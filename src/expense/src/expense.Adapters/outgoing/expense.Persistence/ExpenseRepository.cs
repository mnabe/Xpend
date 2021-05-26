using AutoMapper;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;
using expense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace expense.Persistence
{
    public class ExpenseRepository: IAddExpense
    {
        private readonly IMapper _mapper;
        private readonly ExpenseDataContext _context;

        public ExpenseRepository(IMapper mapper, ExpenseDataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Expense Add(ExpenseCategory expenseCategory, decimal expenseCost)
        {
            Expense expense = new Expense();
            expense.ExpenseCategory = expenseCategory;
            expense.ExpenseCost = expenseCost;
            ExpenseEntity entity = _mapper.Map<ExpenseEntity>(expense);
            _context.Expenses.Add(entity);
            _context.SaveChanges();
            return expense;
        }
    }
}
