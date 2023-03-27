using shopping_economy.Application.Commands.ProdutoCommand.DeletarProduto;
using shopping_economy.Application.Commands.ProdutoCommand.InserirProduto;
using shopping_economy.Application.Commands.ProdutoCommand.UpdateProduto;
using shopping_economy.Application.Queries.ObterListagemDeProdutos;
using shopping_economy.Application.Queries.ObterProdutoPorId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace shopping_economy.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] InserirProdutoCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var query = new ObterListagemProdutosQuery();

            return Ok(await _mediator.Send(query));
        }

        [AllowAnonymous]
        [HttpGet("product-by-id")]
        public async Task<IActionResult> GetProductIdAsync([FromQuery] ObterProdutoPorIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPut("{id}/update-product")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProdutoCommand command)
        {
            await _mediator.Send(command);

            return Ok();

        }
        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProductAsync([FromQuery] DeletarProdutoCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}