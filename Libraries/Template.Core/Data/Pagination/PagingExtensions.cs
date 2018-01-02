using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Template.Core.Data.Pagination
{
    public static class PagingExtensions
    {
        private const string PaginationHeaderKey = "X-Pagination";

        public static async Task<Page<T>> ToPagedCollection<T>(
            this IQueryable<T> source,
            PagingOptions pagingOptions,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var size = await source.CountAsync(cancellationToken);
            var items = await source
                .Skip(pagingOptions.PageIndex)
                .Take(pagingOptions.PageSize)
                .ToArrayAsync(cancellationToken);

            return new Page<T>(items, pagingOptions.PageIndex, pagingOptions.PageSize, size);
        }

        public static void AddPaginationHeader<T>(this IHeaderDictionary headers, Page<T> page)
        {
            var metaData = JsonConvert.SerializeObject(page.MetaData, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            headers.Add(PaginationHeaderKey, metaData);
        }
    }
}