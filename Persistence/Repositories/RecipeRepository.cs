using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository 
    {

        public RecipeRepository(RecipeBookContext context) : base(context)
        {
        }
    }
}
