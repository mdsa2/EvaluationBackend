using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.DATA;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using EvaluationBackend.DATA.DTOs.TypeOfVehicle;
using Microsoft.AspNetCore.Authorization;
using EvaluationBackend.Helpers;

namespace EvaluationBackend.Controllers
{
    [Authorize]
    [Route("Vehicle-Type")]
    public class VehiclesTypesController : BaseController
    {
        private readonly ItypeOfVechileService _typeVehicle;
        public VehiclesTypesController(ItypeOfVechileService typeVehicle)
        {
            _typeVehicle = typeVehicle;
        }
        [HttpGet]
        public async Task<ActionResult<Respons<TypeOfVehicleDto>>> GetAll([FromQuery] TypeOfVehicleFilter typeOfVehicleFilter) => Ok(await _typeVehicle.GetAll(typeOfVehicleFilter), typeOfVehicleFilter.PageNumber);
        [HttpPost]
        public async Task<ActionResult<TypeOFVehicleForm>> Add(TypeOFVehicleForm typeOFVehicleForm) => Ok(await _typeVehicle.add(typeOFVehicleForm));
        [HttpPut("{id}")]
        public async Task<ActionResult<Respons<TYpeOFVehicleUpdate>>> Update(int id, TYpeOFVehicleUpdate ypeOFVehicleUpdate) => Ok(await _typeVehicle.update(ypeOFVehicleUpdate, id));
        [HttpDelete("{id}")]
        public async Task<ActionResult<TYpeOFVehicleUpdate>> Delete(int id) => Ok(await _typeVehicle.Delete(id));
    }
}
