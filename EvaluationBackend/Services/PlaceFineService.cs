using EvaluationBackend.DATA.DTOs.Citizen;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.DATA.DTOs.PlaceName;
using AutoMapper;
using EvaluationBackend.Repository;
using EvaluationBackend.DATA.DTOs;

namespace EvaluationBackend.Services
{
    public interface IPlaceFineService
    {
        Task<(PlaceFine? placeFine, string? error)> add(PlaceNameForm placeNameForm);
        Task<(List<PlaceNameDto> placeNameDtos, int? totalCount, string? error)> GetAll(PlaceFilter placeFilter);
        Task<(PlaceFine? placefine, string? error)> update(PlaceNameUpdate placeNameUpdate, int id);
        Task<(PlaceFine? placeFine, string?)> Delete(int id);
    }
    public class PlaceFineService:IPlaceFineService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public PlaceFineService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        public  async Task<(PlaceFine? placeFine, string? error)> add(PlaceNameForm placeNameForm)
        {

            var placename = _mapper.Map<PlaceFine>(placeNameForm);

            var result = await _repositoryWrapper.placeFineRepositry.Add(placename);


            return result == null ? (null, "place could not add") : (placename, null);
        }

        public async Task<(PlaceFine? placeFine, string?)> Delete(int id)
        {
            var placeFine = _repositoryWrapper.placeFineRepositry.GetById(id);
            if (placeFine == null) return (null, "place not found");
            var result = await _repositoryWrapper.placeFineRepositry.Delete(id);
            return result == null ? (null, "result could not be deleted") : (result, null);
        }

        public async Task<(List<PlaceNameDto> placeNameDtos, int? totalCount, string? error)> GetAll( PlaceFilter placeFilter)
        {
            var (placeNameDtos, totalCount) = await _repositoryWrapper.placeFineRepositry.GetAll<PlaceNameDto>();


            return (placeNameDtos, totalCount, null);
        }

        public async Task<(PlaceFine placefine, string? error)> update(PlaceNameUpdate placeNameUpdate, int id)
        {
            var placefine = await _repositoryWrapper.placeFineRepositry.GetById(id);
            if (placefine == null)
            {
                return (null, "place not found");
            }
            var placefines = new PlaceFine
            {
                Name = placeNameUpdate.PlaceName,
              


            };
            var response = await _repositoryWrapper.placeFineRepositry.Update(placefines);
            return response == null ? (null, "citizen could not be updated") : (placefines, null);
        }
    }
}
