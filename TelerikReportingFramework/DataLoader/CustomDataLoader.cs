using System.Data;

namespace TelerikReportingFramework.DataLoader
{
    public class CustomDataLoader : IDataLoader
    {
        public DataTable GetData(string connectionString, string query)
        {
            // Implement custom data loading logic
            return new DataTable();
        }
    }
}