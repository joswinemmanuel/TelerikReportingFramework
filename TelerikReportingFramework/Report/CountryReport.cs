using System.Collections.Generic;
using System.Data;
using System;
using TelerikReportingFramework.Reports;

namespace TelerikReportingFramework.Reports
{
    public partial class CountryReport : BaseReport
    {
        public CountryReport()
        {
            // We have to give connection string and query needed to be on the report here
            InitializeComponent();

            AddSortExpression("CountryName", SortDirection.Ascending);
            AddSortExpression("Population", SortDirection.Descending);


            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=countrydb;Integrated Security=True";
            string query = "SELECT CountryId, CountryName, Population, Area FROM Countries;";
            InitializeReport(connectionString, query);
        }

        public override void AddAdditionalColumns(System.Data.DataTable dataTable)
        {
            var random = new Random();
            var columnsToAdd = new List<(string Name, Type Type, Func<DataRow, int, object> ValueGenerator)>
            {
                ("Password", typeof(string), (DataRow row, int index) => GenerateRandomString(8, random)),
                ("Number", typeof(int), (DataRow row, int index) => random.Next(1, 101)),
                ("Person", typeof(string), (DataRow row, int index) => $"Person {index + 1}"),
                // We can add more columns as we need
            };

            AddColumnsToDataTable(dataTable, columnsToAdd);
        }

    }
}