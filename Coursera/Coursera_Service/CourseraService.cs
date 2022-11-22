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
        public async Task<List<CourseraResponse>> ReturnReport(int minCredit, DateOnly startDate, DateOnly endDate, string directory, string? outputFormat, params string?[] pins)
        {
            var data = await _dbContext.Students
                .Include(x => x.StudentsCoursesXrefs)
                .ThenInclude(x => x.Course)
                .ThenInclude(x => x.Instructor)
                .ToListAsync();

            var response = new List<CourseraResponse>();
            foreach (var student in data)
            {
                var courses = await GetCoursesByStudentPIN(student.Pin);
                var entity = new CourseraResponse()
                {
                    StudentName = $"{student.FirstName} {student.LastName}",
                    Courses= courses,
                    TotalCredit = GetCoursesTotalCredit(courses),
            };
                response.Add(entity);
            }
            return response;
        }
        private async Task<List<CourseResponse>> GetCoursesByStudentPIN(string pin)
        {
            var data = await _dbContext.Courses
                .Include(x => x.Instructor)
                .Include(x=>x.StudentsCoursesXrefs)
                .Where(x=>x.StudentsCoursesXrefs.Any(x=>x.StudentPin==pin)).ToListAsync();

            var response = new List<CourseResponse>();

            foreach (var course in data)
            {
                response.Add(new CourseResponse()
                {
                    CourseName = course.Name,
                    Credit = course.Credit,
                    InstructorName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",
                    Time = course.TotalTime,
                });
            }
            return response;
        }
        private int GetCoursesTotalCredit(List<CourseResponse> courses)
        {
           var response = courses.Select(x => x.Credit).Sum();
            return response;
        }
    }
}
