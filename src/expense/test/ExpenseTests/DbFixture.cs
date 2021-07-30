using expense.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExpenseTests
{
    public class DbFixture
    {
        private readonly DbContextOptions<ExpenseDataContext> _options;
        internal ExpenseDataContext ExpenseDataContext { get; private set; }
        public DbFixture()
        {
            _options = new DbContextOptionsBuilder<ExpenseDataContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            ExpenseDataContext = new ExpenseDataContext(_options);
        }
    }
}