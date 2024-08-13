using System.Collections.Generic;
using System.Data;
using System;
using TelerikReportingFramework.Reports;

namespace TelerikReportingFramework.Reports
{
    public partial class PatientReport : BaseReport
    {
        public PatientReport()
        {
            // We have to give connection string and query needed to be on the report here
            InitializeComponent();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=carestackdb;Integrated Security=True";
            string query = "SELECT FirstName, LastName, Age, Country, Gender, Address, PhoneNumber, Email, DateOfBirth, MedicalHistory FROM Patients;";
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
                ("Dummy", typeof(int), (DataRow row, int index) => random.Next(1, 1001)+12),
                // We can add more columns as we need
            };

            AddColumnsToDataTable(dataTable, columnsToAdd);
        }

    }
}