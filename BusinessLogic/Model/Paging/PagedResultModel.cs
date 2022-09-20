namespace Infrastructure.Core.Models.Paging
{
    using System.Collections.Generic;

    public class PagedResultModel<T>
    {
        public int TotalRecords { get; set; }

        public List<T> Items { get; set; }
    }
}
