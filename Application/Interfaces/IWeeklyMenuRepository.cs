using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWeeklyMenuRepository : IRepository<WeeklyMenuItem>
    {
        Task<IEnumerable<WeeklyMenuItem>> GetFullWeekMenu();
        Task<IEnumerable<WeeklyMenuItem>> GetShoppingList();
    }
}
