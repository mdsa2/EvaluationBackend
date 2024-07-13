using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using EvaluationBackend.Services;
using EvaluationBackend.DATA.DTOs.Citizen;
using EvaluationBackend.DATA.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace EvaluationBackend.Controllers
{
    [Authorize]
    public class CitizensController : BaseController
    {
        private readonly ICitizenService _citizenService;
        
        public CitizensController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }
        [HttpGet]     




          

        public async Task<ActionResult<Respons<CitizenDto>>> GetAll([FromQuery] CitizenFilter citizenFilter) => Ok(await _citizenService.GetAll(citizenFilter),citizenFilter.PageNumber);
        [HttpPost]
        public async Task<ActionResult<CitizenDto>> Add(CitizenForm citizenForm) => Ok(await _citizenService.add(citizenForm));
        [HttpPut("{id}")]
        public async Task<ActionResult<Respons<UpdateCitizen>>> Update(int id, UpdateCitizen updateCitizen) => Ok(await _citizenService.update(updateCitizen, id));
        [HttpDelete("{id}")]
        public async Task<ActionResult<CitizenDto>> Delete(int id) => Ok(await _citizenService.Delete(id));
    }
}
