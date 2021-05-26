using Microsoft.EntityFrameworkCore;
using System;

namespace expense.Persistence
{
    public class ExpenseDataContext: DbContext
    {
        public ExpenseDataContext(DbContextOptions<ExpenseDataContext> options): base(options)
        {
        }

        public virtual DbSet<ExpenseEntity> Expenses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ExpenseEntity>()
                .HasKey(c => c.ExpenseId);
        }
    }
}
