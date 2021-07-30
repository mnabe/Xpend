using AutoFixture;
using AutoFixture.AutoMoq;
using expense.Domain.Enums;
using expense.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ExpenseTests
{
    public class TestFixture
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
    }
}
