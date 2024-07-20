using EvaluationBackend.DATA;
using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA.DTOs.Reports;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationBackend.Controllers
{
    [Authorize]
    public class ReportsPlatesController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportsPlatesController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet]
        public async Task<ActionResult<Respons<FinePlates>>> GetAll([FromQuery] FineFilter filter)=>Ok( await _reportService.GetAll(filter),filter.PageNumber);
        
    }
}
