using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.DATA.DTOs;
using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.DATA.DTOs.PlaceName;
using EvaluationBackend.DATA.DTOs.VehicleCity;
using EvaluationBackend.Entities;
using EvaluationBackend.Repository;
using OneSignalApi.Model;

namespace EvaluationBackend.Services
{
    public interface IVehicleCityService
    {
        Task<(VehiclesCity? vehicleCity, string? error)> add(VehicleCityForm vehicleCityForm);
        Task<(List<VehicleCityDto> vehicleCityDto, int? totalCount, string  ? error)> GetAll(VehicleCityFilter vehicleCityFilter);
        Task<(VehiclesCity? vehicleCity, string? error)> update(VehicleCityUpdate vehicleCityUpdate, int id);
        Task<(VehiclesCity? vehicleCity, string?)> Delete(int id);
    }
    public class VehicleCityService : IVehicleCityService

    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public VehicleCityService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository= repository;
            _mapper = mapper;

        }

        public async Task<(VehiclesCity? vehicleCity, string? error)> add(VehicleCityForm vehicleCityForm)
        {
            var Vehiclecity = new VehiclesCity
            {

                City = vehicleCityForm.CityOfVehicle
            };

            var result = await _repository.VehicleCityRepositry.Add(Vehiclecity);


            return result == null ? (null, "gov could not add") : (Vehiclecity, null);
        }

        public async Task<(VehiclesCity? vehicleCity, string?)> Delete(int id)
        {
            var fine = await _repository.VehicleCityRepositry.GetById(id);
            if (fine == null) return (null, "Gov not found");
            var result = await _repository.VehicleCityRepositry.Delete(id);
            return result == null ? (null, "result could not be deleted") : (result, null);
        }

        public async Task<(List<VehicleCityDto> vehicleCityDto, int? totalCount, string? error)> GetAll(VehicleCityFilter vehicleCityFilter)
        {
            var (vehicleCityDto, totalCount) = await _repository.VehicleCityRepositry.GetAll<VehicleCityDto>();


            return (vehicleCityDto, totalCount, null);
        }

        public async Task<(VehiclesCity? vehicleCity, string? error)> update(VehicleCityUpdate vehicleCityUpdate, int id)
        {
            var gov = await _repository.VehicleCityRepositry.GetById(id);
            if (gov == null)
            {
                return (null, "gov not found");
            }
            gov.City = vehicleCityUpdate.CityOfVehicle;
            var response = await _repository.VehicleCityRepositry.Update(gov);
            return response == null ? (null, "gov could not be updated") : (gov, null);
        }
    }
}
