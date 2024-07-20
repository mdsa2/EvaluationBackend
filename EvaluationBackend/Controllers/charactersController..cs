using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.DATA;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Mvc;
using EvaluationBackend.DATA.DTOs.Characters;
using EvaluationBackend.DATA.DTOs;


namespace EvaluationBackend.Controllers
{
    public class charactersController : BaseController
    {
        private readonly ICharacterService _characterService;
        public charactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        [HttpGet]
        public async Task<ActionResult<Respons<CharacterDto>>> GetAll([FromQuery] characterFilter filter) => Ok(await _characterService.GetAll(filter), filter.PageNumber);
        [HttpPost]
        public async Task<ActionResult<characterForm>> Add(characterForm characterForm) => Ok(await _characterService.add(characterForm));
        [HttpPut("{id}")]
        public async Task<ActionResult<Respons<characterUpdate>>> Update(int id, characterUpdate characterUpdate) => Ok(await _characterService.update(characterUpdate, id));
        [HttpDelete("{id}")]
        public async Task<ActionResult<characterForm>> Delete(int id) => Ok(await _characterService.Delete(id));
    }
}
