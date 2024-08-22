using System.Data;

namespace TelerikReportingFramework.DataLoader
{
    public interface IDataLoader
    {
        DataTable GetData(string connectionString, string query);
    }
}