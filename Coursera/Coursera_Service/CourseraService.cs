using Coursera_Data;
using Coursera_Service.Interfaces;
using Coursera_ViewModel.Responses;
using Microsoft.EntityFrameworkCore;

namespace Coursera_Service
{
    public class CourseraService : ICourseraService
    {
        private readonly CourseraContext _dbContext;

        public CourseraService(CourseraContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CourseraResponse>> ReturnReport(int? minCredit, DateOnly? startDate, DateOnly? endDate, string? directory, string? outputFormat, params int?[] pins)
        {
            var data = _dbContext.Students
                .Include(x => x.StudentsCoursesXrefs)
                .ThenInclude(x => x.Course)
                .ThenInclude(x => x.Instructor)
                .ToList();

            var response = new List<CourseraResponse>();
            return response;
        }
    }
}
