using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos.ProductDtos;
using My_City_Project.Dtos.ReportDtos;
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
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllReports()
        {
            var reports = _reportService.GetAllReports();
            var result = _mapper.Map<List<ResultReportDto>>(reports);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetReportById(Guid id)
        {
            var report = _reportService.GetReportById(id);
            if (report == null)
                return NotFound("Report not found");
            var result = _mapper.Map<GetByIdReportDto>(CreateReport);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateReport([FromBody] CreateReportDto createReportDto)
        {

            var report = _mapper.Map<Report>(createReportDto);
            _reportService.CreateReport(report);

            return Ok(report);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateReport(Guid id, [FromBody] UpdateReportDto updateReportDto)
        {
            var report = _reportService.GetReportById(id);

            _mapper.Map(updateReportDto, report);
            _reportService.UpdateReport(report);
            return Ok(report);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReport(Guid id)
        {
            var report = _reportService.GetReportById(id);
            _reportService.DeleteReport(id);
            return Ok("Report Silme Başarılı");
        }
    }
}
