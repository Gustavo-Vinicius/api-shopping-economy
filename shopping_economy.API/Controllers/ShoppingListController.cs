using MediatR;
using Microsoft.AspNetCore.Mvc;
using shopping_economy.Application.Commands.ListOfTheMonthCommand.CompareListPrices;
using shopping_economy.Application.Commands.ListOfTheMonthCommand.CreateListTheMonth;

namespace shopping_economy.API.Controllers
{
    [ApiController]
    [Route("api/shopping-list")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateListTheMonthAsync([FromBody] CreateListTheMonthCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> CompareListPricesAsync([FromQuery]CompareListPricesCommand command)
        {
            var result = await _mediator.Send(command);

           string valueFormating = String.Format("Amount: {0:C}", result);

            return Ok(valueFormating);
        }
    }
}