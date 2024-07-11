using EvaluationBackend.DATA.DTOs.Citizen;
using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using EvaluationBackend.DATA.DTOs.Vehical;
using EvaluationBackend.Interface;
using EvaluationBackend.Services;
using Microsoft.AspNetCore.Authorization;

namespace EvaluationBackend.Controllers
{
    [Authorize]
    public class VehicleController : BaseController
    {
        private readonly IVehicaleService _vehicaleService;
        public VehicleController(IVehicaleService vehicaleService)
        {

            _vehicaleService = vehicaleService;
        }


        [HttpGet]
        public async Task<ActionResult<Respons<VehicalDto>>> GetAll([FromQuery] vehicleFilter vehicleFilter) => Ok(await _vehicaleService.GetAll(vehicleFilter), vehicleFilter.PageNumber);
        [HttpPost]
        public async Task<ActionResult<VehicalDto>> Add(VehicalForm vehicalForm) => Ok(await _vehicaleService.Add(vehicalForm));
 
        [HttpPut("{id}")]
        public async Task<ActionResult<Respons<VehicalUpdate>>> Update(int id, VehicalUpdate vehicalUpdate) => Ok(await _vehicaleService.Update(vehicalUpdate, id));
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicalDto>> Delete(int id) => Ok(await _vehicaleService.Delete(id));
    }
}
