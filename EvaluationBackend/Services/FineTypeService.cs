using EvaluationBackend.DATA.DTOs.Citizen;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.DATA.DTOs.FineType;
using AutoMapper;
using EvaluationBackend.Repository;
using EvaluationBackend.DATA.DTOs.Fine;
 

namespace EvaluationBackend.Services
{
    public interface IFineTypeService
    {
        Task<(FineTypes? fineType, string? error)> add(FineTypeForm fineTypeForm);
        Task<(List<FineTypeDto> fineTypeDtos, int? totalCount, string? error)> GetAll(FineTypeFilter fineTypeFilter);
        Task<(FineTypes? fineType, string? error)> update(FineTypeUpdate fineTypeUpdate, int id);
        Task<(FineTypes? fineType, string?)> Delete(int id);
    }


    public class FineTypeService : IFineTypeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public FineTypeService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        public async Task<(FineTypes? fineType, string? error)> add(FineTypeForm fineTypeForm)
        {
            var finetype = new FineTypes { Name = fineTypeForm.Name 
            , Price = fineTypeForm.Price
            };

            var result = await _repositoryWrapper.fineTypeRepositry.Add(finetype);


            return result == null ? (null, "finetype could not add") : (finetype, null);
        }

        public async Task<(FineTypes? fineType, string?)> Delete(int id)
        {
            var fine = _repositoryWrapper.fineTypeRepositry.GetById(id);
            if (fine == null) return (null, "fine not found");
            var result = await _repositoryWrapper.fineTypeRepositry.Delete(id);
            return result == null ? (null, "result could not be deleted") : (result, null);
        }

        public async Task<(List<FineTypeDto> fineTypeDtos, int? totalCount, string? error)> GetAll(FineTypeFilter fineTypeFilter)
        {
            var (fineTypeDtos, totalCount) = await _repositoryWrapper.fineTypeRepositry.GetAll<FineTypeDto>();


            return (fineTypeDtos, totalCount, null);
        }

        public async Task<(FineTypes? fineType, string? error)> update(FineTypeUpdate fineTypeUpdate, int id)
        {
            var fineType = await _repositoryWrapper.fineTypeRepositry.GetById(id);
            if (fineType == null)
            {
                return (null, "fine not found");
            }
            var finetypes = new FineTypes
            {
                Name = fineTypeUpdate.Name,
                Price = fineTypeUpdate.Price,
            };
            var response = await _repositoryWrapper.fineTypeRepositry.Update(finetypes);
            return response == null ? (null, "fine could not be updated") : (finetypes, null);
        }
    }
}
