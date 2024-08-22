using System;
using System.Collections.Generic;
using System.Data;
using Telerik.Reporting;
using TelerikReportingFramework.DataLoader;
using TelerikReportingFramework.Models;
using SortDirection = TelerikReportingFramework.Models.SortDirection;

namespace TelerikReportingFramework.Reports
{
    public partial class CountryReport : BaseReport
    {
        public CountryReport() : base()
        {
            InitializeComponent();
            Initialize();
        }

        public CountryReport(IDataLoader dataLoader) : base(dataLoader)
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            // Add sorting expressions
            AddSortExpression("Population", SortDirection.Descending);

            // Add filtering expressions
            AddFilterExpression("Population", FilterOperator.TopN, 10);

            //AddGroupExpression("CountryName");

            // Define connection string and query
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=countrydb;Integrated Security=True";
            string query = "SELECT CountryId, CountryName, Population, Area FROM Countries;";

            // Initialize the report
            InitializeReport(connectionString, query);
        }

        public override void AddAdditionalColumns(DataTable dataTable)
        {
            var random = new Random();
            var columnsToAdd = new List<(string Name, Type Type, Func<DataRow, int, object> ValueGenerator)>
            {
                ("Password", typeof(string), (row, index) => GenerateRandomString(8, random)),
                ("Number", typeof(int), (row, index) => random.Next(1, 101)),
                ("Person", typeof(string), (row, index) => $"Person {index + 1}"),
                // Add more columns as needed
            };

            AddColumnsToDataTable(dataTable, columnsToAdd);
        }
    }
}