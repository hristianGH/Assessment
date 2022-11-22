using Coursera_Service.Interfaces;
using Coursera_ViewModel.Responses;
using CsvHelper;
using Microsoft.AspNetCore.Html;
using System.Globalization;
using System.Text;

namespace Coursera_Service
{
    public class FileWriter : IFileWriter
    {
        public async Task WriteCSV<T>(ICollection<T> values)
        {
            using (var writer = new StreamWriter($"report.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
               await csv.WriteRecordsAsync(values);
            }
            
        }
        public async Task WriteHTML(ICollection<CourseraResponse> values)
        {
            var builder = new HtmlContentBuilder();
            foreach (var item in values)
            {
                builder.AppendFormat("<html><table><tr> </tr> </table> </html>");
            }
            using (var writer = new StreamWriter($"report.html")) ;
          
        }
    }
}
