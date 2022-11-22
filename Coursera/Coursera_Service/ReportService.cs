using Coursera_Data;
using Coursera_Service.Interfaces;
using Coursera_ViewModel.Responses;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Coursera_Service
{
    public class ReportService : IReportService
    {
        private readonly CourseraContext _dbContext;
        private readonly IFileWriter _fileWriter;

        public ReportService(CourseraContext dbContext, IFileWriter fileWriter)
        {
            _dbContext = dbContext;
            _fileWriter = fileWriter;
        }
        public async Task<List<CourseraResponse>> ReturnReport(int minCredit, DateTime startDate, DateTime endDate, string directory, string? outputFormat, params string[]? pins)
        {
            var students = await _dbContext.Students
                .Include(x => x.StudentsCoursesXrefs)
                .ThenInclude(x => x.Course)
                .ThenInclude(x => x.Instructor)
                .ToListAsync();

            if (pins != null)
            {
                students = students.Where(s => pins.Any(x => x == s.Pin)).ToList();
            }

            var response = new List<CourseraResponse>();
            foreach (var student in students)
            {
                var courses = await GetCoursesByStudentPIN(student.Pin);
                var totalCredit = GetCoursesTotalCredit(courses);
                if (totalCredit<minCredit)
                {
                    var entity = new CourseraResponse()
                    {
                        StudentName = $"{student.FirstName} {student.LastName}",
                        Courses = courses,
                        TotalCredit = GetCoursesTotalCredit(courses),
                    };
                    response.Add(entity);
                }
            }
            await WriteToFile(response);
            return response;
        }

        private async Task<List<CourseResponse>> GetCoursesByStudentPIN(string pin)
        {
            var data = await _dbContext.Courses
                .Include(x => x.Instructor)
                .Include(x => x.StudentsCoursesXrefs)
                .Where(x => x.StudentsCoursesXrefs.Any(x => x.StudentPin == pin)).ToListAsync();

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
        private async Task WriteToFile(List<CourseraResponse> data)
        {
            await _fileWriter.WriteCSV(data);
        }
    }
}
