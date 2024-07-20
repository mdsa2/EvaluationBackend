using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using EvaluationBackend.DATA.DTOs;
using Microsoft.AspNetCore.Authorization;
using EvaluationBackend.Helpers;
 
using EvaluationBackend.DATA.DTOs.VehicleGovernareteDtos;

namespace EvaluationBackend.Controllers
{
    [Authorize]
    [Route("Vehicle-Governarete")]
    public class VehicleGovernareteController : BaseController
    {

        private readonly IVehicleCityService _vehicleCityService;
        public VehicleGovernareteController(IVehicleCityService vehicleCityService)
        {
            _vehicleCityService = vehicleCityService;
        }
        [HttpGet]
        public async Task<ActionResult<Respons<VehicleGovernareteDto>>> GetAll([FromQuery] VehicleCityFilter vehicleCityFilter) => Ok(await _vehicleCityService.GetAll(vehicleCityFilter),vehicleCityFilter.PageNumber);
        [HttpPost]
        public async Task<ActionResult<VehicleGovernareteDto>> Add(VehicleGovernareteForm vehicleCityForm) => Ok(await _vehicleCityService.add(vehicleCityForm));
        [HttpPut("{id}")]
        public async Task<ActionResult<Respons<VehicleGovernareteUpdate>>> Update(int id, VehicleGovernareteUpdate vehicleCityUpdate) => Ok(await _vehicleCityService.update(vehicleCityUpdate, id));
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleGovernareteDto>> Delete(int id) => Ok(await _vehicleCityService.Delete(id));
    }
}
