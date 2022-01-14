using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class WeeklyMenuRepository : Repository<WeeklyMenuItem>, IWeeklyMenuRepository
    {
        public WeeklyMenuRepository(RecipeBookContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<WeeklyMenuItem>> GetFullWeekMenu()
        {
            var items = await ((RecipeBookContext)Context).WeeklyMenuItems
                .AsNoTracking()
                .Include(i => i.DinnerRecipe)
                .Include(i => i.LunchRecipe)
                .ToListAsync();

            return items;
        }
    }
}
