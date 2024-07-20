using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.DATA.DTOs.TypeOfVehicle;
using AutoMapper;
using EvaluationBackend.Repository;
using EvaluationBackend.DATA.DTOs.PlaceName;
using EvaluationBackend.DATA.DTOs.GovDto;

namespace EvaluationBackend.Services
{
    public interface ItypeOfVechileService
    {
        Task<(TypeOfVehicles? typeOfVehicle, string? error)> add(TypeOFVehicleForm typeOFVehicleForm);
        Task<(List<TypeOfVehicleDto> typeOfVehicleDtos, int? totalCount, string? error)> GetAll(TypeOfVehicleFilter typeOfVehicleFilter);
        Task<(TypeOfVehicles? type, string? error)> update(TYpeOFVehicleUpdate ypeOFVehicleUpdate, int id);
        Task<(Fine? fine, string?)> Delete(int id);
    }
    public class typeOfVehicleService : ItypeOfVechileService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public typeOfVehicleService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        public async Task<(TypeOfVehicles? typeOfVehicle, string? error)> add(TypeOFVehicleForm typeOFVehicleForm)
        {
            var typeOfVehicle = new TypeOfVehicles
            {
                Name = typeOFVehicleForm.vehicleType
            };
           

            var result = await _repositoryWrapper.itypeOfVehicleRepositry.Add(typeOfVehicle);


            return result == null ? (null, "type of vehicle could not add") : (typeOfVehicle, null);
        }

        public async Task<(Fine? fine, string?)> Delete(int id)
        {
            var typeOfVehicle = _repositoryWrapper.itypeOfVehicleRepositry.GetById(id);
            if (typeOfVehicle == null) return (null, "fine not found");
            var result = await _repositoryWrapper.itypeOfVehicleRepositry.Delete(id);
            return result == null ? (null, "result could not be deleted") : (null, null);
        }

        public async Task<(List<TypeOfVehicleDto> typeOfVehicleDtos, int? totalCount, string? error)> GetAll(TypeOfVehicleFilter typeOfVehicleFilter)
        {
            var (placeNameDtos, totalCount) = await _repositoryWrapper.itypeOfVehicleRepositry.GetAll<TypeOfVehicleDto>();


            return (placeNameDtos, totalCount, null);



        }

        public async Task<(TypeOfVehicles? type, string? error)> update(TYpeOFVehicleUpdate ypeOFVehicleUpdate, int id)
        {
            var type = await _repositoryWrapper.itypeOfVehicleRepositry.GetById(id);
            if (type == null)
            {
                return (null, "gov not found");
            }

            type.Name = ypeOFVehicleUpdate.vehicleType;
         
            var response = await _repositoryWrapper.itypeOfVehicleRepositry.Update(type);
            return response == null ? (null, "gov could not be updated") : (type, null);
        }
    }
}
