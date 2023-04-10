using shopping_economy.Application.Commands.ProdutoCommand.DeletarProduto;
using shopping_economy.Application.Commands.ProdutoCommand.InserirProduto;
using shopping_economy.Application.Commands.ProdutoCommand.UpdateProduto;
using shopping_economy.Application.Queries.ObterListagemDeProdutos;
using shopping_economy.Application.Queries.ObterProdutoPorId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopping_economy.Core.DTOs;

namespace shopping_economy.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Produces("application/json")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Insert new products into the database.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A newly created product</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "description": "Item #1/1",
        ///        "price": 00.00
        ///        "stock": 100
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Insert product</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProductAsync([FromBody] InserirProdutoCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
      
        /// <summary>
        /// Returns list of registered products.
        /// </summary>
        /// <response code="200">Returns list of registered products</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(ProductDTO), 200)]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var query = new ObterListagemProdutosQuery();

            return Ok(await _mediator.Send(query));
        }
        
        /// <summary>
        /// Search product by id.
        /// </summary>
        /// <response code="200"> Search product by id</response>
        [ProducesResponseType(typeof( ProductDTO), 200)]
        [AllowAnonymous]
        [HttpGet("product-by-id")]
        public async Task<IActionResult> GetProductIdAsync([FromQuery] ObterProdutoPorIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Edit product by id.
        /// </summary>
        /// <param name="command"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT/product
        ///     {
        ///         "produto": 
        ///            {
        ///             "id": 0,
        ///             "name": "TESTE",
        ///             "description": "TESTE#1",
        ///             "price": 0.00,
        ///             "stock": 0,
        ///             "storeId": 0
        ///            },
        ///             "id": 0
        ///      }
        /// </remarks>
        /// <response code="201">Edit product by id</response>
        /// <response code="400">If the product is null</response>
        [HttpPut("{id}/update-product")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProdutoCommand command)
        {
            await _mediator.Send(command);

            return Ok();

        }

        /// <summary>
        /// Deletes a specific product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProductAsync([FromQuery] DeletarProdutoCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}