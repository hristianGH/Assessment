
using Coursera_ViewModel.Responses;

namespace Coursera_Service.Interfaces
{
    public interface ICourseraService
    {
        Task<List<CourseraResponse>> ReturnReport(int minCredit,DateOnly startDate,DateOnly endDate,string directory,string? outputFormat,params int?[] pins);
    }
}
