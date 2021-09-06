using Application.Recipes.Commands;
using Application.Recipes.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class RecipeController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            var recipe = await Mediator.Send(new GetRecipeByIdQuery {Id = id});
            return Ok(recipe);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipe()
        {
            var recipes = await Mediator.Send(new GetAllRecipesQuery());
            return Ok(recipes);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByRecipeName([FromQuery] string name)
        {
            var recipes = await Mediator.Send(new SearchByRecipeNameQuery {Name = name});
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] CreateRecipeCommand command)
        {
            await Mediator.Send(command);
            return Created("", null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeById(int id) {
            await Mediator.Send(new DeleteRecipeCommand { Id = id});
            return NoContent();
        }
    }
}
