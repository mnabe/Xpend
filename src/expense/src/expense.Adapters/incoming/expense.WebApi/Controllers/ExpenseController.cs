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
        private readonly IGetExpense _getExpense;
        public ExpenseController(ICreateExpense createExpense, IGetExpenses getExpenses, IGetExpense getExpense)
        {
            _createExpense = createExpense;
            _getExpenses = getExpenses;
            _getExpense = getExpense;
        }

        [HttpGet("id")]
        public ActionResult GetExpense(int id)
        {
            var response = _getExpense.GetExpense(id);
            return Ok(response);
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
