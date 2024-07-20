using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA;
using AutoMapper;
using EvaluationBackend.Repository;
using OneSignalApi.Model;

namespace EvaluationBackend.Services
{
    public interface IReportPlatesService
    {

        Task<(List<FinePlates> name, int? totalCount, string? error)> GetAll(FineFilter filter);

    }
    public class ReportPlatesService : IReportPlatesService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public ReportPlatesService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        public async Task<(List<FinePlates> name, int? totalCount, string? error)> GetAll(FineFilter filter)
        {
            var (name, totalCount) = await _repositoryWrapper.reportRepositry.GetAll<FinePlates>(


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
