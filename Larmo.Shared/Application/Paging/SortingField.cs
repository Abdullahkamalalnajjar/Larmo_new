namespace Larmo.Shared.Application.Paging;

public class SortingField(string field, SortDirection direction)
{
    public SortingField() : this(null, SortDirection.Ascending)
    {
    }

    public string Field { get; set; } = field;

    public SortDirection Direction { get; set; } = direction;
}