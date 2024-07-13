using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.DATA;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using EvaluationBackend.DATA.DTOs.TypeOfVehicle;
using Microsoft.AspNetCore.Authorization;

namespace EvaluationBackend.Controllers
{
    [Authorize]
    public class VehiclesTypeController : BaseController
    {
        private readonly ItypeOfVechileService _typeVehicle;
        public VehiclesTypeController(ItypeOfVechileService typeVehicle)
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
