using Application.Recipes.Commands;
using Application.Recipes.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
  public class RecipeController : BaseController
    {
        [HttpGet]
        [Route("{id}")]
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

        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] CreateRecipeCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
