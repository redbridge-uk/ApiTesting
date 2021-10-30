namespace Redbridge.ApiTesting.Framework.Extensions
{
    public interface IPagedTask
    {
        int Page { get; set; }
        int Size { get; set; }
        string Sorting { get; set; }
        string Filter { get; set; }
    }
}