namespace Smart.Paging;

/// <summary>
/// PaginationParams:
/// PageSize has minimum of 5
/// </summary>
public class PaginationParams
{
    /// <summary>
    /// Deconstruct
    /// </summary>
    /// <param name="pageSize"></param>
    /// <param name="page"></param>
    public void Deconstruct(out int pageSize, out int page)
    {
        pageSize = PageSize;
        page = Page;
    }

    /// <summary>
    /// PageSize
    /// </summary>
    public int PageSize { get; set; } = 5;
    /// <summary>
    /// Page
    /// </summary>
    public int Page { get; set; } = 1;
};