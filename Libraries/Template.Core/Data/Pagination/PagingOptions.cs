using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Template.Core.Data.Pagination
{
    public sealed class PagingOptions
    {
        public const int MaxPageSize = 100;

        [FromQuery]
        [Range(1, int.MaxValue, ErrorMessage = "PageIndex must be greater than 0.")]
        public int PageIndex { get; set; } = 1;

        [FromQuery]
        [Range(1, MaxPageSize, ErrorMessage = "PageSize must be greater than 0 and less than 100.")]
        public int PageSize { get; set; } = MaxPageSize;
    }
}