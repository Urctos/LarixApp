namespace WebAPI.Filters
{
    public class PaginationFilter
    {
        private readonly int maxPageSize = 25;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter()
        {
            PageSize = maxPageSize;
            PageNumber = 1;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > maxPageSize ? maxPageSize : pageSize;

        }
    }
}
