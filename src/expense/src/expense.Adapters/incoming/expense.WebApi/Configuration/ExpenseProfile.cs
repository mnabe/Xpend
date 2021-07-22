using AutoMapper;
using expense.Domain.Entities;
using expense.Persistence;

namespace expense.WebApi.Configuration
{
    public class ExpenseProfile: Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseEntity>();
            CreateMap<ExpenseEntity, Expense>();
        }
    }
}
