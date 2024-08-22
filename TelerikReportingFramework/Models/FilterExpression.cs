using Telerik.Reporting;

namespace TelerikReportingFramework.Models
{
    public class FilterExpression
    {
        public string PropertyName { get; set; }
        public FilterOperator Operator { get; set; }
        public object Value { get; set; }
    }
}