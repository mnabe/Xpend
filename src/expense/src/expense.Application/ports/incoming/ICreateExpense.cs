namespace expense.Application.ports.incoming
{
    public interface ICreateExpense
    {
        public bool CreateExpense(CreateExpenseCommand command);
    }
}
