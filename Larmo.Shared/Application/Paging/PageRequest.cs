namespace Larmo.Shared.Application.Paging;

public class PageRequest
{
    public PagingOptions PagingOptions { get; set; } = new();

    public FilterOptions FilterBuilder { get; set; }

    public string Filter { get; set; }

    public SortingField SortingField { get; set; }
}