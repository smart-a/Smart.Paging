namespace Smart.Paging;

/// <summary>
/// Pagination
/// </summary>
public static class Pagination
{
    private static readonly int MAX_PAGE_SIZE = 50;
    private static readonly int MIN_PAGE_SIZE = 5;
    
    /// <summary>
    /// Paginate
    /// </summary>
    /// <param name="source"></param>
    /// <param name="paginationParams"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>PaginationResult</returns>
    public static PaginationResult<T> Paginate<T>(this IQueryable<T> source, PaginationParams paginationParams)
    {
        var (pageSize, page) = paginationParams;
        return ExecutePaging(source, page, pageSize);
    }
    
    /// <summary>
    /// Paginate
    /// </summary>
    /// <param name="source"></param>
    /// <param name="pageSize"></param>
    /// pageSize: minimum size of 5
    /// <param name="page"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>PaginationResult</returns>
    public static PaginationResult<T> Paginate<T>(this IQueryable<T> source, int pageSize, int page)
    {
        return ExecutePaging(source, page, pageSize);
    }
    
    /// <summary>
    /// Paginate
    /// </summary>
    /// <param name="source"></param>
    /// <param name="pageSize"></param>
    /// pageSize: minimum size of 5
    /// <typeparam name="T"></typeparam>
    /// <returns>PaginationResult</returns>
    public static PaginationResult<T> Paginate<T>(this IQueryable<T> source, int pageSize)
    {
        return ExecutePaging(source, 1, pageSize);
    }


    // Private functions
    
    private static PaginationResult<T> ExecutePaging<T>(IQueryable<T> source, int page, int pageSize)
    {
        page = page < 1 ? 1 : page;
        pageSize = pageSize < MIN_PAGE_SIZE ? MIN_PAGE_SIZE : pageSize;
        pageSize = pageSize > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : pageSize;
        
        var count = source.Count();
        var items = source.Skip((page - 1) * pageSize)
            .Take(pageSize);
        var totalPages = (int) Math.Ceiling(count / (double) pageSize);

        return new PaginationResult<T>
        {
            CurrentPage = page,
            Data = items,
            CurrentPageRecord = items.Count(),
            PageSize = pageSize,
            NextPage = page < totalPages ? page + 1 : null,
            PreviousPage = page > 1 && totalPages > 1 ? page - 1 : null,
            TotalPages = totalPages,
            TotalRecord = count
        };
    }
}
