
using Coursera_ViewModel.Responses;

namespace Coursera_Service.Interfaces
{
    public interface IReportService
    {
        Task<List<CourseraResponse>> ReturnReport(int minCredit, DateTime startDate, DateTime endDate, string directory, string? outputFormat, params string[]? pins);
    }
}
