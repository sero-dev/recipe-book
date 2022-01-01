using Application.WeeklyMenu.Commands;
using Application.WeeklyMenu.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class WeeklyMenuController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllWeeklyMenuItems() 
        {
            var items = await Mediator.Send(new GetWeeklyMenuQuery());
            return Ok(items);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWeeklyMenuItems([FromBody] IEnumerable<WeeklyMenuItemDto> menu)
        {
            await Mediator.Send(new UpdateWeeklyMenuCommand(menu));
            return Ok();
        }
    }
}
