using expense.Application.ports.incoming;
using expense.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public ExpenseController(ICreateExpense createExpense, IGetExpenses getExpenses, 
            IGetExpense getExpense, IEditExpense editExpense)
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
        public async Task<IActionResult> GetExpense([Required] int id)
        {
            try
            {
                Expense response = await _getExpense.GetExpense(id);
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

        [ResponseCache(Duration = 60)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            try
            {
                IEnumerable<Expense> response = await _getExpenses.GetExpenses();
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

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateExpense(string expenseCategory, decimal expenseCost)
        {
            try
            {
                CreateExpenseCommand command = new CreateExpenseCommand(expenseCategory, expenseCost);
                var response = await _createExpense.CreateExpense(command);
                if (response is string)
                {
                    return BadRequest(response);
                }
                return CreatedAtAction(nameof(GetExpense), response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(Name = PutExpense)]
        public async Task<IActionResult> EditExpense(int id, string expenseCategory, decimal expenseCost)
        {   
            try
            {
                EditExpenseCommand command = new EditExpenseCommand(id, expenseCategory, expenseCost);
                Expense response = await _editExpense.EditExpense(command);
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
    }
}