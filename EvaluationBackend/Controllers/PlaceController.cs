using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.DATA;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using EvaluationBackend.DATA.DTOs.PlaceName;
using Microsoft.AspNetCore.Authorization;

namespace EvaluationBackend.Controllers
{
 
    public class PlaceController : BaseController
    {
        private readonly IPlaceFineService _placeNameService;
        public PlaceController(IPlaceFineService placeNameService)
        {
            _placeNameService = placeNameService;
        }
        [HttpGet]
        public async Task<ActionResult<Respons<PlaceNameDto>>> GetAll() => Ok(await _placeNameService.GetAll());
        [HttpPost]
        public async Task<ActionResult<PlaceNameForm>> Add(PlaceNameForm placeNameForm) => Ok(await _placeNameService.add(placeNameForm));
        [HttpPut("{id}")]
        public async Task<ActionResult<Respons<PlaceNameUpdate>>> Update(int id, PlaceNameUpdate placeNameUpdate) => Ok(await _placeNameService.update(placeNameUpdate, id));
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlaceNameDto>> Delete(int id) => Ok(await _placeNameService.Delete(id));
    }
}
