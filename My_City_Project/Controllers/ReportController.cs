using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Implementations;
using My_City_Project.Services.Interfaces;

namespace My_City_Project.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult GetAllReports()
        {
            var reports = _reportService.GetAllReports();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public IActionResult GetReportById(Guid id)
        {
            var report = _reportService.GetReportById(id);
            if (report == null)
                return NotFound("Report not found");
            return Ok(report);
        }

        [HttpPost]
        public IActionResult CreateReport([FromBody] Report report)
        {
            if (report == null)
                return BadRequest("Report bilgisi boş olamaz.");

            if (report.Id == Guid.Empty)
                report.Id = Guid.NewGuid();

            _reportService.CreateReport(report);

            return Ok(report);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateReport(Guid id, Report report)
        {
            if (id != report.Id)
                return BadRequest("ID mismatch");

            _reportService.UpdateReport(report);
            return Ok(report);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReport(Guid id)
        {
            _reportService.DeleteReport(id);
            return Ok("Report deleted successfully");
        }
    }
}
