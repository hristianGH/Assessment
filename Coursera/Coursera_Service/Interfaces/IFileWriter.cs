
using Coursera_ViewModel.Responses;
using System.Text;

namespace Coursera_Service.Interfaces
{
    public interface IFileWriter
    {
        Task WriteCSV<T>(ICollection<T> values);
        Task WriteHTML<T>(ICollection<CourseraResponse> values);

    }
}
