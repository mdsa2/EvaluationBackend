using EvaluationBackend.DATA.DTOs.Citizen;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.DATA.DTOs.Characters;
using AutoMapper;
using EvaluationBackend.Repository;
using EvaluationBackend.DATA.DTOs.GovDto;
using OneSignalApi.Model;
using EvaluationBackend.DATA.DTOs;

namespace EvaluationBackend.Services
{
    public interface ICharacterService
    {
        Task<(Character? character, string? error)> add(characterForm characterForm);
        Task<(List<CharacterDto> characterDtos, int? totalCount, string? error)> GetAll(characterFilter filter);
        Task<(Character character, string? error)> update(characterUpdate characterUpdate, int id);
        Task<(Character character, string?)> Delete(int id);

    }
    public  class CharacterService : ICharacterService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public CharacterService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        public async Task<(Character? character, string? error)> add(characterForm characterForm)
        {
            var character = new Character
            {

                CharacterName = characterForm.characterName
            };

            var result = await _repositoryWrapper.characterRepositry.Add(character);


            return result == null ? (null, "gov could not add") : (character, null);
        }

        public async Task<(Character character, string?)> Delete(int id)
        {
            var character = _repositoryWrapper.characterRepositry.GetById(id);
            if (character == null) return (null, "Gov not found");
            var result = await _repositoryWrapper.characterRepositry.Delete(id);
            return result == null ? (null, "result could not be deleted") : (result, null);
        }

        public async Task<(List<CharacterDto> characterDtos, int? totalCount, string? error)> GetAll(characterFilter filter)
        {
            {
                var (characterDtos, totalCount) = await _repositoryWrapper.characterRepositry.GetAll<CharacterDto>();


                return (characterDtos, totalCount, null);
            }
        }

 

        public async Task<(Character character, string? error)> update(characterUpdate characterUpdate, int id)
        {
            var characters = await _repositoryWrapper.characterRepositry.GetById(id);
            if (characters == null)
            {
                return (null, "gov not found");
            }

            characters.CharacterName = characterUpdate.characterName;
            var response = await _repositoryWrapper.characterRepositry.Update(characters);
            return response == null ? (null, "gov could not be updated") : (characters, null);
        }
    }
}
