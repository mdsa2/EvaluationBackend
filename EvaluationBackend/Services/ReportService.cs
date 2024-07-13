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
 
        Task<( List<FineUserDto> name, int? totalCount, string? error)> GetAll(FineFilter fineFilter);
    
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
        public async Task<( List<FineUserDto> name, int? totalCount, string? error)> GetAll(FineFilter fineFilter)
        {
            var (s, s1) = await _repositoryWrapper.reportRepositry.GetAll();
          

            var (name, totalCount) = await _repositoryWrapper.reportRepositry.GetAll<FineUserDto>(

       f => (f.Number == fineFilter.number || fineFilter.number == null) &&
       (f.Status == fineFilter.Status || fineFilter.Status == null)  ,
          
            fineFilter.PageNumber, fineFilter.PageSize
           
            );
         
            


            return (name, totalCount, null);
        }
    }
}
