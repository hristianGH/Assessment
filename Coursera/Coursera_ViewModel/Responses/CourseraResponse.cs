
namespace Coursera_ViewModel.Responses
{
    public class CourseraResponse
    {
        public string? StudentName { get; set; }
        public ICollection<CourseResponse> Courses { get; set; } = new List<CourseResponse>();
        public int TotalCredit { get; set; }
    }
}
