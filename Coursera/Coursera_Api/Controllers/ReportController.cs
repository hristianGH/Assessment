using Coursera_Service.Interfaces;
using Coursera_ViewModel.Requests;
using Coursera_ViewModel.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coursera_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<CourseraResponse>> Get([FromQuery] GetReportsRequest request)
        {
            var response = await _service.ReturnReport(request.MinimumCredit,request.StartDate,request.EndDate,request.OutputDirectory,request.OutputFormat,request.StudentPins);
            return response;
        }
    }
}
