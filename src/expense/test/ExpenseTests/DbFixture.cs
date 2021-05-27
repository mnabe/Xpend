using expense.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTests
{
    public class DbFixture: IDisposable
    {
        private readonly DbContextOptions<ExpenseDataContext> _options;
        public ExpenseDataContext ExpenseDataContext { get; set; }
        public DbFixture()
        {
            _options = new DbContextOptionsBuilder<ExpenseDataContext>()
               .UseInMemoryDatabase("db").Options;
            ExpenseDataContext = new ExpenseDataContext(_options);
        }

        public void Dispose()
        {
            ExpenseDataContext.Dispose();
        }
    }
}
