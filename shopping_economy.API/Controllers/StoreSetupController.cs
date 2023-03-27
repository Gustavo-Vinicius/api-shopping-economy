using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shopping_economy.Application.Commands.StoreSetupCommand.InsertStoreSetup;

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
    }
}