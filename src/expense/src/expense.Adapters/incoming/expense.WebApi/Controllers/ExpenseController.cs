using expense.Application.ports.incoming;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace expense.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ICreateExpense _createExpense;
        private readonly IGetExpenses _getExpenses;
        public ExpenseController(ICreateExpense createExpense, IGetExpenses getExpenses)
        {
            _createExpense = createExpense;
            _getExpenses = getExpenses;
        }

        [HttpGet]
        public ActionResult GetExpenses()
        {
            var response = _getExpenses.GetExpenses();
            return Ok(response);
        }
 
        [HttpPost]
        public ActionResult CreateExpense(string expenseCategory, decimal expenseCost)
        {
            CreateExpenseCommand command = new CreateExpenseCommand(expenseCategory, expenseCost);
            _createExpense.CreateExpense(command);
            return Ok(command); //should be changed to CreatedAtAction
        }
    }
}
