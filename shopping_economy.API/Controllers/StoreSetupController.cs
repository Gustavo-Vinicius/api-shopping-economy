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

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] StoreSetupCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetListingAsync()
        {
            var query = new GetListingStoreSetupQuery();

            var getListingStoreSetup = await _mediator.Send(query);

            return Ok(getListingStoreSetup);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStoreSetupAsync([FromQuery] DeleteStoreSetupCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}