using AutoMapper;
using expense.Application.ports.outgoing;
using expense.Domain.Entities;
using expense.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
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
        public List<Expense> Find()
        {
            var response = _context.Expenses.AsEnumerable();
            List<Expense> expenses = _mapper.Map<List<Expense>>(response);
            return expenses;
        }
        public Expense Add(ExpenseCategory expenseCategory, decimal expenseCost)
        {
            Expense expense = new Expense(expenseCategory, expenseCost, ExpenseStatus.RECEIVED);
            ExpenseEntity entity = _mapper.Map<ExpenseEntity>(expense);
            _context.Expenses.Add(entity);
            _context.SaveChanges();
            return expense;
        }
        public Expense UpdateExpense(int id, ExpenseCategory expenseCategory, decimal expenseCost)
        {
            var expenseEntity = _context.Expenses.Find(id);
            expenseEntity.ExpenseCategory = expenseCategory;
            expenseEntity.ExpenseCost = expenseCost;
            _context.SaveChanges();
            Expense expense = _mapper.Map<Expense>(expenseEntity);
            return expense;
        }
    }
}
