﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using expense.Persistence;

namespace expense.Persistence.Migrations
{
    [DbContext(typeof(ExpenseDataContext))]
    partial class ExpenseDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("expense.Persistence.ExpenseEntity", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExpenseCategory")
                        .HasColumnType("int");

                    b.Property<decimal>("ExpenseCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ExpenseStatus")
                        .HasColumnType("int");

                    b.HasKey("ExpenseId");

                    b.ToTable("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
