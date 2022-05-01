namespace Sirb.Template.Shared.ViewModels.Base;

public abstract class ListViewModel<T> where T : class
{
    public long TotalRecords { get; set; }
    public long TotalFound { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public List<T>? Records { get; set; }
}
