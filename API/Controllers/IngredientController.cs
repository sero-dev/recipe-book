using Application.Ingredients.Commands;
using Application.Ingredients.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class IngredientController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredientById(int id)
        {
            var ingredient = await Mediator.Send(new GetIngredientByIdQuery {Id = id});
            return Ok(ingredient);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIngredient()
        {
            var ingredients = await Mediator.Send(new GetAllIngredientsQuery());
            return Ok(ingredients);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByIngredientName([FromQuery] string name)
        {
            var ingredients = await Mediator.Send(new SearchByIngredientNameQuery {Name = name});
            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromBody] CreateIngredientCommand command)
        {
            await Mediator.Send(command);
            return Created("", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, [FromBody] UpdateIngredientCommand command) {
            if (id != command.Id) return BadRequest();

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientById(int id) {
            await Mediator.Send(new DeleteIngredientCommand { Id = id});
            return NoContent();
        }
    }
}
