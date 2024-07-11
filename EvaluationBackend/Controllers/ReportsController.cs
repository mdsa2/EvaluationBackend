using EvaluationBackend.DATA;
using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA.DTOs.PlaceName;
using EvaluationBackend.DATA.DTOs.Reports;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationBackend.Controllers
{
 
    public class ReportsController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet]
        public async Task<ActionResult<Respons<ReportsDto>>> GetAll([FromQuery] FineFilter filter)=>Ok( await _reportService.GetAll(filter),filter.PageNumber);
        
    }
}
