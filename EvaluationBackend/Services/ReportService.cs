using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA.DTOs.PlaceName;
using EvaluationBackend.DATA.DTOs.Reports;
using EvaluationBackend.DATA.DTOs.User;
using EvaluationBackend.Entities;
using EvaluationBackend.Repository;
using OneSignalApi.Model;

namespace EvaluationBackend.Services
{
    public interface IReportService
    {
 
        Task<( List<FineUserDto> name, int? totalCount, string? error)> GetAll(FineFilter filter);
    
    }
    public class ReportService : IReportService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public ReportService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        public async Task<( List<FineUserDto> name, int? totalCount, string? error)> GetAll(FineFilter filter)
        {
         
          

            var (name, totalCount) = await _repositoryWrapper.reportRepositry.GetAll<FineUserDto>(

     f => (f.Vehicle.vehiclesGovernarete.VehicleGovernarte == filter.VehicleGovernarete || filter.VehicleGovernarete == null) &&
             (f.Vehicle.typeOfVechile.Name == filter.Vehicletype || filter.Vehicletype == null) &&

             (f.Vehicle.NumberOfVechile == filter.numbervehicle || filter.numbervehicle == null) &&
         
               (f.Vehicle.character.CharacterName == filter.character || filter.VehicleId == null),




        filter.PageNumber, filter.PageSize

            );
         
            


            return (name, totalCount, null);
        }
    }
}
