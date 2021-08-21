using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _service;

        public RecipeController(ILogger<RecipeController> logger, IRecipeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRecipe(int id)
        {
            try
            {
                RecipeDTO recipe = _service.GetRecipeById(id);
                return recipe is not null ? Ok(recipe) : NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        public IActionResult GetAllRecipe()
        {
            try {
                IEnumerable<RecipeDTO> recipes = _service.GetAllRecipes();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
            
        }

        [HttpPost]
        public IActionResult AddRecipe([FromBody] RecipeDTO recipe)
        {
            try
            {
                int? id = _service.AddRecipe(recipe);
                return id is null ? new StatusCodeResult(500) : Created("", id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(500);
            }
            
        }
    }
}
