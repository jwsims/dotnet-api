using System;
using System.Collections.Generic;

namespace Template.Core.Data.Pagination
{
    public sealed class Page<T> : List<T>
    {
        public Page(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            AddRange(source);
            MetaData.PageIndex = pageIndex;
            MetaData.PageSize = pageSize;
            MetaData.TotalCount = totalCount;
            MetaData.TotalPages = (int) Math.Ceiling(totalCount / (double) pageSize);
            MetaData.HasNextPage = pageIndex < MetaData.TotalPages;
            MetaData.HasPreviousPage = pageIndex > 1;
        }

        public PagingMetaData MetaData { get; } = new PagingMetaData();
    }
}