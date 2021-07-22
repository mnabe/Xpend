using expense.Application.ports.incoming;
using expense.Application.ports.outgoing;
using expense.Application.services;
using expense.Domain.Entities;
using expense.Persistence;
using expense.WebApi.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sciensoft.Hateoas.Extensions;
using System.Reflection;

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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddResponseCaching();
            services.AddPersistenceDependencies(Configuration);
            services.AddScoped<ICreateExpense, CreateExpenseService>();
            services.AddScoped<IAddExpense, ExpenseRepository>();
            services.AddScoped<IGetExpenses, GetExpensesService>();
            services.AddScoped<IFindExpenses, ExpenseRepository>();
            services.AddScoped<IGetExpense, GetExpenseService>();
            services.AddScoped<IFindExpense, ExpenseRepository>();
            services.AddScoped<IEditExpense, EditExpenseService>();
            services.AddScoped<IUpdateExpense, ExpenseRepository>();
            services.AddSwaggerGen();
            services.AddControllers().AddLink(builder =>
            {
                builder.AddPolicy<Expense>(model =>
                {
                    model.AddRoute(m => m.ExpenseId, ExpenseController.PutExpense, message: "Put expense");
                    model.AddRoute(m => m.ExpenseId, ExpenseController.FindExpense, message: "Find expense");
                });
            }).ConfigureApiBehaviorOptions(options =>
            {
                //Disable responses with status code 4xx and higher from being translated into a ProblemDetails result
                options.SuppressMapClientErrors = true;
            });
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
            app.UseResponseCaching();
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
