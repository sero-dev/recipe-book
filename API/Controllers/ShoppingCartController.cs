using Application.ShoppingCart.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ShoppingCartController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetShoppingCart()
        {
            var r = await Mediator.Send(new GetShoppingCartItemsQuery());
            return Ok(r);
        }
    }
}
