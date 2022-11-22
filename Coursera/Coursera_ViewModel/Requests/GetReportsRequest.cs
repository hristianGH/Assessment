
using System.Diagnostics.CodeAnalysis;

namespace Coursera_ViewModel.Requests
{
    public class GetReportsRequest
    {
        
        public int MinimumCredit { get; set; }
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public string OutputDirectory { get; set; }
        public string? OutputFormat { get; set; }
        public string[]? StudentPins { get; set; }
    }
}
