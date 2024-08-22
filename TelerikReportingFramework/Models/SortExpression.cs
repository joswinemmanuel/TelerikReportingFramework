namespace TelerikReportingFramework.Models
{
    public class SortExpression
    {
        public string PropertyName { get; set; }
        public SortDirection Direction { get; set; }
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
}