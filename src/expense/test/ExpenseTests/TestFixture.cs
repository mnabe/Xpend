using AutoFixture;
using expense.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTests
{
    public class TestFixture: IDisposable
    {
        private readonly DbContextOptions<ExpenseDataContext> _options;
        internal ExpenseDataContext ExpenseDataContext { get; private set; }
        public Fixture Fixture { get; private set; }
        public TestFixture()
        {
            _options = new DbContextOptionsBuilder<ExpenseDataContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            ExpenseDataContext = new ExpenseDataContext(_options);
            Fixture = new Fixture();
        }

        public void Dispose()
        {
            ExpenseDataContext.Dispose();

        }
    }
}
