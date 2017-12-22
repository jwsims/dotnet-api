using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Template.Core.Data.Pagination;
using Template.Data.Entities;
using Template.Services.Production;
using Template.Services.Production.Models;

namespace Template.Web.Controllers
{
    [Route("api/products")]
    public class ProductsController : BaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet(Name = nameof(GetProducts))]
        public async Task<IActionResult> GetProducts(
            PagingOptions pagingOptions,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var products = await productService.GetProducts(pagingOptions, cancellationToken);

            Response.Headers.AddPaginationHeader(products);

            return Ok(products);
        }
    }
}