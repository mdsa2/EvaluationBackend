using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using EvaluationBackend.DATA.DTOs.VehicleCity;
using EvaluationBackend.DATA.DTOs;
using Microsoft.AspNetCore.Authorization;
using EvaluationBackend.Helpers;

namespace EvaluationBackend.Controllers
{
    [Authorize]
    [Route("Vehicle-City")]
    public class VehicleCityController : BaseController
    {

        private readonly IVehicleCityService _vehicleCityService;
        public VehicleCityController(IVehicleCityService vehicleCityService)
        {
            _vehicleCityService = vehicleCityService;
        }
        [HttpGet]
        public async Task<ActionResult<Respons<VehicleCityDto>>> GetAll([FromQuery] VehicleCityFilter vehicleCityFilter) => Ok(await _vehicleCityService.GetAll(vehicleCityFilter),vehicleCityFilter.PageNumber);
        [HttpPost]
        public async Task<ActionResult<VehicleCityDto>> Add(VehicleCityForm vehicleCityForm) => Ok(await _vehicleCityService.add(vehicleCityForm));
        [HttpPut("{id}")]
        public async Task<ActionResult<Respons<VehicleCityUpdate>>> Update(int id, VehicleCityUpdate vehicleCityUpdate) => Ok(await _vehicleCityService.update(vehicleCityUpdate, id));
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleCityDto>> Delete(int id) => Ok(await _vehicleCityService.Delete(id));
    }
}
