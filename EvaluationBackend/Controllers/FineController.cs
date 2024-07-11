using EvaluationBackend.DATA;
using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationBackend.Controllers
{
 [Authorize]
    public class FinesController : BaseController
    {
   
     private readonly IFineService _fineService;
        public FinesController(IFineService fineService)
        {
            _fineService = fineService;
        }
        [HttpGet]
        public async Task<ActionResult<Respons<FineDto>>> GetAll([FromQuery] FineFilter filter) => Ok(await _fineService.GetAll(filter),filter.PageNumber);
        [HttpPost]
        public async Task<ActionResult<FineForm>> Add(FineForm fineForm)=> Ok(await _fineService.add(fineForm));
        [HttpPut("{id}")]
        public async Task<ActionResult<Respons<FineUpdateDto>>> Update(int id,FineForm fineForm)=>Ok(await _fineService.update(fineForm,id));
        [HttpDelete("{id}")]
        public async Task<ActionResult<FineDto>> Delete(int id ) =>Ok( await _fineService.Delete(id));
    }
}
