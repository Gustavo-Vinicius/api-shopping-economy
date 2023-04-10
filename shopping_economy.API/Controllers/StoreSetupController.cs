using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shopping_economy.Application.Commands.StoreSetupCommand.DeleteStoreSetup;
using shopping_economy.Application.Commands.StoreSetupCommand.InsertStoreSetup;
using shopping_economy.Application.Queries.GetListStoreSetup;

namespace shopping_economy.API.Controllers
{
    [ApiController]
    [Route("api/store-setup")]
    public class StoreSetupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreSetupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add a new store to enter products.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A newly created product</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///       {
        ///         "productName": "string",
        ///         "date": "string",
        ///         "price": 0,
        ///         "totalPrice": 0,
        ///         "clientId": 0
        ///       }       
        /// </remarks>
        /// <response code="201">Add new store</response>
        /// <response code="400">This store is already created</response>
        [HttpPost("add-new-store")]
        public async Task<IActionResult> AddNewStoreAsync([FromBody] StoreSetupCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// Search registered stores.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListingAsync()
        {
            var query = new GetListingStoreSetupQuery();

            var getListingStoreSetup = await _mediator.Send(query);

            return Ok(getListingStoreSetup);
        }

        /// <summary>
        /// Deletes a specific store.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete-store")]
        public async Task<IActionResult> DeleteStoreSetupAsync([FromQuery] DeleteStoreSetupCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}