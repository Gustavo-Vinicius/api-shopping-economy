using MediatR;
using Microsoft.AspNetCore.Mvc;
using shopping_economy.Application.Commands.ListOfTheMonthCommand.CreateListTheMonth;
using shopping_economy.Application.Queries.ListOfTheMonthCommand.CompareListPrices;

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

        /// <summary>
        /// Register products to make the purchase of the month.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A newly created product</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///        {
        ///         "productName": "string",
        ///         "date": "string",
        ///         "price": 0,
        ///         "totalPrice": 0,
        ///         "clientId": 0
        ///        }     
        /// </remarks>
        /// <response code="201">Add product for month</response>
        [HttpPost("register-product-month")]
        public async Task<IActionResult> CreateListTheMonthAsync([FromBody] CreateListTheMonthCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// Compare the price of the list of products registered in the current month with the previous month.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CompareListPricesAsync([FromQuery]CompareListPricesQuery command)
        {
            var result = await _mediator.Send(command);

           string valueFormating = String.Format("Amount: {0:C}", result);

            return Ok(valueFormating);
        }
    }
}