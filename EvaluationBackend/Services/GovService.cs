using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA.DTOs.GovDto;
using EvaluationBackend.Entities;
using EvaluationBackend.Repository;
using Microsoft.EntityFrameworkCore;

namespace EvaluationBackend.Services
{
    public interface IGovService
    {
        Task<(Gov? gov, string? error)> add(GovForm govs);
        Task<(List<GovsDto> gov, int? totalCount, string? error)> GetAll(GovFilter filter);
        Task<(Gov? gov, string? error)> update( int id,UpdateGov updateGov);
        Task<(Gov? gov, string?)> Delete(int id);
    }
    public class GovService : IGovService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public GovService(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<(Gov? gov, string? error)> add(GovForm? govs)
        {

            var gov = new Gov {
                
                Name = govs.Name 
            };

            var result = await _repositoryWrapper.govRepositry.Add(gov);


            return result == null ? (null, "gov could not add") : (gov, null);
        }

        public async  Task<(Gov? gov, string?)> Delete(int id)
        {
            var fine = _repositoryWrapper.govRepositry.GetById(id);
            if (fine == null) return (null, "Gov not found");
            var result = await _repositoryWrapper.govRepositry.Delete(id);
            return result == null ? (null, "result could not be deleted") : (result, null);
        }

        public async Task<(List<GovsDto> gov, int? totalCount, string? error)> GetAll(GovFilter filter)
        {
            var (gov, totalCount) = await _repositoryWrapper.govRepositry.GetAll<GovsDto>((g=>
            g.Name == filter.Name || filter.Name==null
            
            
            
            ),filter.PageNumber,filter.PageSize);


            return (gov, totalCount, null);
        }

        public async Task<(Gov? gov, string? error)> update(int id,UpdateGov govform )
        {
            var gov = await _repositoryWrapper.govRepositry.GetById(id);
            if (gov == null)
            {
                return (null, "gov not found");
            }
            gov.Name = govform.Name;
            var response = await _repositoryWrapper.govRepositry.Update(gov);
            return response == null ? (null, "gov could not be updated") : (gov, null);
        }
    }
}
