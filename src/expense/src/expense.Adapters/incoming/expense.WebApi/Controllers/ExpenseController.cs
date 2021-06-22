using expense.Application.ports.incoming;
using expense.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace expense.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        public const string FindExpense = nameof(FindExpense);
        public const string PutExpense = nameof(PutExpense);

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

        [ResponseCache(Duration = 60, VaryByQueryKeys = new string[] { "id" })]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id", Name = FindExpense)]
        public async Task<ActionResult<Expense>> GetExpense([Required] int id)
        {
            try
            {
                var response = await _getExpense.GetExpense(id);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }        
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

        [HttpPut(Name = PutExpense)]
        public ActionResult EditExpense(int id, string expenseCategory, decimal expenseCost)
        {
            EditExpenseCommand command = new EditExpenseCommand(id, expenseCategory, expenseCost);
            var response = _editExpense.EditExpense(command);
            return Ok(response);
        }
    }
}
