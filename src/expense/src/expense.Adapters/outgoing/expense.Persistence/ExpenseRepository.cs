using AutoMapper;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;
using expense.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace expense.Persistence
{
    internal class ExpenseRepository: IAddExpense, IFindExpenses, IFindExpense, IUpdateExpense
    {
        private readonly IMapper _mapper;
        private readonly ExpenseDataContext _context;

        public ExpenseRepository(IMapper mapper, ExpenseDataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Expense> Find(int id)
        {
            var response = await _context.Expenses.FindAsync(id);
            Expense expense = _mapper.Map<Expense>(response);
            return expense;
        }
        public async Task<IEnumerable<Expense>> Find()
        {
            var response = await _context.Expenses.ToListAsync();
            IEnumerable<Expense> expenses = _mapper.Map<IEnumerable<Expense>>(response);
            return expenses;
        }
        public async Task<Expense> Add(ExpenseCategory expenseCategory, decimal expenseCost)
        {
            Expense expense = new Expense(expenseCategory, expenseCost, ExpenseStatus.RECEIVED);
            ExpenseEntity entity = _mapper.Map<ExpenseEntity>(expense);
            await _context.Expenses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return expense;
        }
        public async Task<Expense> UpdateExpense(int id, ExpenseCategory expenseCategory, decimal expenseCost)
        {
            var expenseEntity = await _context.Expenses.FindAsync(id);
            expenseEntity.ExpenseCategory = expenseCategory;
            expenseEntity.ExpenseCost = expenseCost;
            await _context.SaveChangesAsync();
            Expense expense = _mapper.Map<Expense>(expenseEntity);
            return expense;
        }
    }
}
