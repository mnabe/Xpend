using AutoMapper;
using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Application.services;
using expense.Domain.Entities;
using expense.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace expense.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Expense, ExpenseEntity>();
                cfg.CreateMap<ExpenseEntity, Expense>();
            });
            IMapper mapper = configuration.CreateMapper();
            services.AddPersistenceDependencies(Configuration);
            services.AddSingleton(mapper); services.AddScoped<ICreateExpense, CreateExpenseService>();
            services.AddScoped<ICreateExpense, CreateExpenseService>();
            services.AddScoped<IAddExpense, ExpenseRepository>();
            services.AddScoped<IGetExpenses, GetExpensesService>();
            services.AddScoped<IFindExpenses, ExpenseRepository>();
            services.AddScoped<IGetExpense, GetExpenseService>();
            services.AddScoped<IFindExpense, ExpenseRepository>();
            services.AddScoped<IEditExpense, EditExpenseService>();
            services.AddScoped<IUpdateExpense, ExpenseRepository>();
            services.AddSwaggerGen();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Xpend API v1");
           });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
