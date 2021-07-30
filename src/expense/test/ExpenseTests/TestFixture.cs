using AutoFixture;
using AutoFixture.AutoMoq;
using expense.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExpenseTests
{
    public class TestFixture
    {
        public Fixture Fixture { get; private set; }
        public TestFixture()
        {
            Fixture = new Fixture();
            Fixture.Customize(new AutoMoqCustomization());
        }
    }
}
