namespace Infrastructure.Core.Models.Paging
{
  
    public class PagingFilterModel
    {
        public int PageSize { get; set; }

        public int Page { get; set; }

        public string SortColumn { get; set; }

    
        public bool BypassPaging { get; set; } // used by the export service to get all records
    }
}
