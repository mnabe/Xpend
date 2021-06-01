using expense.Domain.Entities;

namespace expense.Application.ports.outgoing
{
    public interface IFindExpense
    {
        Expense Find(int id);
    }
}
