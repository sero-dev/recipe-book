﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe> 
    {
        Task<Recipe> GetFullRecipe(int Id);
    }
}
