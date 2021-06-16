using expense.Application.ports.incoming;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IEditExpense _editExpense;
        public ExpenseController(ICreateExpense createExpense, IGetExpenses getExpenses, IGetExpense getExpense, IEditExpense editExpense)
        {
            _createExpense = createExpense;
            _getExpenses = getExpenses;
            _getExpense = getExpense;
            _editExpense = editExpense;
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetExpense(int id)
        {
            var response = await _getExpense.GetExpense(id);
            if (response == null)
            {
                return NotFound();
            }
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
            return CreatedAtAction(nameof(GetExpense), command);
        }

        [HttpPut]
        public ActionResult EditExpense(int id, string expenseCategory, decimal expenseCost)
        {
            EditExpenseCommand command = new EditExpenseCommand(id, expenseCategory, expenseCost);
            var response = _editExpense.EditExpense(command);
            return Ok(response);
        }
    }
}
