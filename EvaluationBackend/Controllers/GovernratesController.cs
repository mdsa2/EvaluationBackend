using EvaluationBackend.DATA;
 
using EvaluationBackend.DATA.DTOs.GovDto;
 
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 

namespace EvaluationBackend.Controllers
{
    [Authorize]
    public class GovernratesController : BaseController
    {
        private readonly IGovService _govService;
     public GovernratesController(IGovService govService)
        {
            _govService = govService;
        }
        [HttpGet]
        public async Task<ActionResult<Respons<GovsDto>>> GetAll([FromQuery]GovFilter filter) => Ok(await _govService.GetAll(filter), filter.PageNumber);
        [HttpPost]
        public async Task<ActionResult<GovForm>> Add(GovForm govForm) => Ok(await _govService.add(govForm));
        [HttpPut("{id}")]
        public async Task<ActionResult<Respons<GovsDto>>> Update(int id, UpdateGov govUpdate) => Ok(await _govService.update(id, govUpdate));
        [HttpDelete("{id}")]
        public async Task<ActionResult<GovForm>> Delete(int id) => Ok(await _govService.Delete(id));
    }
}
