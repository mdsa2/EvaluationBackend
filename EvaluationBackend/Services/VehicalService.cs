using EvaluationBackend.DATA.DTOs.ArticleDto;
using EvaluationBackend.DATA.DTOs;
using EvaluationBackend.Entities;
using EvaluationBackend.DATA.DTOs.Vehical;
using EvaluationBackend.DATA.DTOs.Fine;
using AutoMapper;
using EvaluationBackend.Repository;
 
using EvaluationBackend.DATA;
using OneSignalApi.Model;

namespace EvaluationBackend.Services
{
    public interface IVehicaleService
    {
        Task<(Vehical? vehical, string? error)> Add(VehicalForm vehicalForm);
    
        Task<(List<VehicalDto> vehicalDtos, int? totalCount, string? error)> GetAll(vehicleFilter vehicleFilter);
        Task<(Vehical? vehical, string? error)> Update(VehicalUpdate vehicalUpdate, int id);
        Task<(Vehical? vehical, string?)> Delete(int id);
    }
    public class VehicalService : IVehicaleService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public VehicalService(IMapper mapper , IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
            
        }
        public async Task<(Vehical? vehical, string? error)> Add(VehicalForm vehicalForm)
        {
            var vehicle = _mapper.Map<Vehical>(vehicalForm);

 

            var result = await _repositoryWrapper.IVehicalRepositry.Add(vehicle);


            return result == null ? (null, "vehicle could not add") : (vehicle, null);
        }

 

        public async Task<(Vehical? vehical, string?)> Delete(int id)
        {
            var vehicle = _repositoryWrapper.IVehicalRepositry.GetById(id);
            if (vehicle == null) return (null, "vehicle not found");
            var result = await _repositoryWrapper.IVehicalRepositry.Delete(id);
            return result == null ? (null, "result could not be deleted") : (result, null);
        }

        public async Task<(List<VehicalDto> vehicalDtos, int? totalCount, string? error)> GetAll(vehicleFilter vehicleFilter)
        {
            var (vehicle, totalCount) = await _repositoryWrapper.IVehicalRepositry.GetAll<VehicalDto>(
        
                
                );

            return (vehicle, totalCount, null);
        }

        public async Task<(Vehical? vehical, string? error)> Update(VehicalUpdate vehicalUpdate, int id)
        {
            var vehical = await _repositoryWrapper.IVehicalRepositry.GetById(id);
            if (vehical == null)
            {
                return (null, "vehicle not found");
            }
            vehical = _mapper.Map(vehicalUpdate, vehical);
            var response = await _repositoryWrapper.IVehicalRepositry.Update(vehical);
            return response == null ? (null, "vehical could not be updated") : (vehical, null);
        }
    }
}
