using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.DATA.DTOs;
using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.DATA.DTOs.PlaceName;
using EvaluationBackend.DATA.DTOs.VehicleGovernareteDtos;

using EvaluationBackend.Entities;
using EvaluationBackend.Repository;
using OneSignalApi.Model;

namespace EvaluationBackend.Services
{
    public interface IVehicleCityService
    {
        Task<(VehiclesGovernarete? vehicleCity, string? error)> add(VehicleGovernareteForm vehicleCityForm);
        Task<(List<VehicleGovernareteDto> vehicleCityDto, int? totalCount, string  ? error)> GetAll(VehicleCityFilter vehicleCityFilter);
        Task<(VehiclesGovernarete? vehicleCity, string? error)> update(VehicleGovernareteUpdate vehicleCityUpdate, int id);
        Task<(VehiclesGovernarete? vehicleCity, string?)> Delete(int id);
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

        public async Task<(VehiclesGovernarete? vehicleCity, string? error)> add(VehicleGovernareteForm vehicleCityForm)
        {
            var Vehiclecity = new VehiclesGovernarete
            {

                VehicleGovernarte = vehicleCityForm.VehicleGovernarete
            };

            var result = await _repository.VehicleCityRepositry.Add(Vehiclecity);


            return result == null ? (null, "gov could not add") : (Vehiclecity, null);
        }

        public async Task<(VehiclesGovernarete? vehicleCity, string?)> Delete(int id)
        {
            var fine = await _repository.VehicleCityRepositry.GetById(id);
            if (fine == null) return (null, "Gov not found");
            var result = await _repository.VehicleCityRepositry.Delete(id);
            return result == null ? (null, "result could not be deleted") : (result, null);
        }

        public async Task<(List<VehicleGovernareteDto> vehicleCityDto, int? totalCount, string? error)> GetAll(VehicleCityFilter vehicleCityFilter)
        {
            var (vehicleCityDto, totalCount) = await _repository.VehicleCityRepositry.GetAll<VehicleGovernareteDto>();


            return (vehicleCityDto, totalCount, null);
        }

        public async Task<(VehiclesGovernarete? vehicleCity, string? error)> update(VehicleGovernareteUpdate vehicleCityUpdate, int id)
        {
            var gov = await _repository.VehicleCityRepositry.GetById(id);
            if (gov == null)
            {
                return (null, "gov not found");
            }
            gov.VehicleGovernarte = vehicleCityUpdate.VehicleGovernarete;
            var response = await _repository.VehicleCityRepositry.Update(gov);
            return response == null ? (null, "gov could not be updated") : (gov, null);
        }
    }
}
