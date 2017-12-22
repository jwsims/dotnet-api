using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Template.Core.Data.Pagination;
using Template.Data;
using Template.Services.Production.Models;

namespace Template.Services.Production
{
    public class ProductService : IProductService
    {
        private readonly AppDataContext dataContext;

        public ProductService(AppDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Page<ProductViewModel>> GetProducts(
            PagingOptions pagingOptions,
            CancellationToken cancellationToken)
        {
            return await dataContext
                .Products
                .OrderBy(x => x.Name)
                .ProjectTo<ProductViewModel>()
                .ToPagedCollection(pagingOptions, cancellationToken);
        }
    }

    public interface IProductService
    {
        Task<Page<ProductViewModel>> GetProducts(
            PagingOptions pagingOptions,
            CancellationToken cancellationToken);
    }
}