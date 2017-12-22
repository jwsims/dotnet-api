using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template.Core.Data.Pagination;
using Template.Services.Production;
using Template.Web.Models.Production;

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
            Page<ProductViewModel> products =
                await this.productService.GetProducts<ProductViewModel>(pagingOptions, cancellationToken);

            this.Response.Headers.AddPaginationHeader(products);

            return this.Ok(products);
        }
    }
}