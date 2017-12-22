using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Template.Core.Data.Pagination;
using Template.Data;

namespace Template.Services.Production
{
    public class ProductService : IProductService
    {
        private readonly AppDataContext dataContext;

        public ProductService(AppDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Page<T>> GetProducts<T>(
            PagingOptions pagingOptions,
            CancellationToken cancellationToken)
        {
            return await this.dataContext
                .Products
                .OrderBy(x => x.Name)
                .ProjectTo<T>()
                .ToPagedCollection(pagingOptions, cancellationToken);
        }
    }

    public interface IProductService
    {
        Task<Page<T>> GetProducts<T>(
            PagingOptions pagingOptions,
            CancellationToken cancellationToken);
    }
}