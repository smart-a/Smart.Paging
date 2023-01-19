namespace Smart.Paging;

/// <summary>
/// PaginationResult
/// </summary>
/// <typeparam name="T"></typeparam>
public class PaginationResult<T>
{
    /// <summary>
    /// CurrentPage
    /// </summary>
    public int CurrentPage { get; init; }
    /// <summary>
    /// Data
    /// </summary>
    public IEnumerable<T> Data { get; init; } = null!;
    /// <summary>
    /// CurrentPageRecord
    /// </summary>
    public int CurrentPageRecord { get; init; }
    /// <summary>
    /// PageSize
    /// </summary>
    public int PageSize { get; init; }
    /// <summary>
    /// NextPage
    /// </summary>
    public int? NextPage { get; init; }
    /// <summary>
    /// PreviousPage
    /// </summary>
    public int? PreviousPage { get; init; }
    /// <summary>
    /// TotalPages
    /// </summary>
    public int TotalPages { get; init; }
    /// <summary>
    /// TotalRecord
    /// </summary>
    public int TotalRecord { get; init; }
}