using System;
using System.IO;
using System.Web;
using Telerik.Reporting;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.Engine;
using Telerik.Reporting.Services.WebApi;

namespace TelerikReportingFramework.Controllers
{
    [Obsolete]
    public class CustomReportResolver : IReportResolver
    {
        private readonly string reportsPath;

        public CustomReportResolver(string reportsPath)
        {
            this.reportsPath = reportsPath;
        }

        public ReportSource Resolve(string reportName)
        {
            // First, try to resolve as a file
            //var filePath = Path.Combine(reportsPath, reportName + ".trdp");
            //if (File.Exists(filePath))
            //{
            //    return new UriReportSource { Uri = filePath };
            //}

            // If not a file, try to resolve as a type
            var typeName = $"TelerikReportWebAPI.Reports.{reportName}, TelerikReportWebAPI";
            var type = Type.GetType(typeName);
            if (type != null && typeof(Telerik.Reporting.Report).IsAssignableFrom(type))
            {
                return new TypeReportSource { TypeName = typeName };

            }

            // If neither worked, return null
            return null;
        }
    }
    public class ReportsController : ReportsControllerBase
    {
        static ReportServiceConfiguration configurationInstance;

        [Obsolete]
        static ReportsController()
        {
            var appPath = HttpContext.Current.Server.MapPath("~/");
            var reportsPath = Path.Combine(appPath, "Reports");

            Console.WriteLine($"Reports path: {reportsPath}");

            var resolver = new CustomReportResolver(reportsPath);

            configurationInstance = new ReportServiceConfiguration
            {
                HostAppId = "Html5App",
                Storage = new FileStorage(),
                ReportResolver = resolver,
            };
        }

        public ReportsController()
        {
            //Initialize the service configuration
            this.ReportServiceConfiguration = configurationInstance;
        }
    }
}