using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager.Models
{
    public static class DatabaseManagement
    { 
        public static List<Report> Reports = new List<Report>();
        public static List<List<Report>> ReportSearchResults { get; set; } = new List<List<Report>>();
        public static Report SelectedReport = new();

        
        public static void AddReportToDb(Report report)
        {
            using (Context context = new Context())
            {
                report.Id = context.Reports.Count();
                context.Reports.Add(report);
                context.SaveChanges();
            }
        }

        public static void DeleteReportFromDb(Report report)
        {
            using (Context context = new Context())
            {
                Report reportToRemove = context.Reports.First(p => p.Id == report.Id);
                context.Reports.Remove(reportToRemove);
                context.Entry(reportToRemove).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void MarkReportComplete(Report report)
        {
            using (Context context = new Context())
            {
                Report reportToEdit = context.Reports.First(p => p.Id == report.Id);
                reportToEdit.DeletePersonalInfo();
                reportToEdit.Completed = true;
                context.Entry(reportToEdit).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
