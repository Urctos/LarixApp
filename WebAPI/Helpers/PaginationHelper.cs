using WebAPI.Filters;
using WebAPI.Wrappers;

namespace WebAPI.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<IEnumerable<T>> CreatePagedResponse<T>(IEnumerable<T> pagedData, PaginationFilter validPaginationFilter, int totalRecords)
        {
            var response = new PagedResponse<IEnumerable<T>>(pagedData, validPaginationFilter.PageNumber, validPaginationFilter.PageSize);
            var totalPages =  ((double)totalRecords / (double)validPaginationFilter.PageSize);
            var roundedTotalPages =  Convert.ToInt32(Math.Ceiling(totalPages));
            int curentPage = validPaginationFilter.PageNumber;

            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            response.PreviousPage = curentPage > 1 ? true : false;
            response.NextPage = curentPage < roundedTotalPages ? true : false;

            return response;

        }
    }
}
