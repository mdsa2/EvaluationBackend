using EvaluationBackend.DATA.DTOs.Fine;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.DATA.DTOs.Citizen;
using EvaluationBackend.Repository;
using EvaluationBackend.DATA.DTOs.GovDto;
using OneSignalApi.Model;
using AutoMapper;

namespace EvaluationBackend.Services
{
    public interface ICitizenService
    {
        Task<(Citizen? citizens, string? error)> add(CitizenForm citizenForm);
        Task<(List<CitizenDto> Citizens, int? totalCount, string? error)> GetAll(CitizenFilter citizenFilter);
        Task<(Citizen citizens, string? error)> update(UpdateCitizen updateCitizen, int id);
        Task<(Citizen? citizen, string?)> Delete(int id);
    }
    public class CitizenService : ICitizenService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public CitizenService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        public async Task<(Citizen? citizens, string? error)> add(CitizenForm citizenForm)
        {

            var citizen = _mapper.Map<Citizen>(citizenForm);

            var result = await _repositoryWrapper.citizenRepositry.Add(citizen);


            return result == null ? (null, "Citizen could not add") : (citizen, null);
        }

        public async Task<(Citizen? citizen, string?)> Delete(int id)
        {
            var citizen = await _repositoryWrapper.citizenRepositry.GetById(id);
            if (citizen == null) return (null, "Citizen not found");
            var result = await _repositoryWrapper.citizenRepositry.Delete(id);
            return result == null ? (null, "result could not be deleted") : (result, null);
        }

        public async Task<(List<CitizenDto> Citizens, int? totalCount, string? error)> GetAll(CitizenFilter citizenFilter)

        {
          
            var (Citizens, totalCount) = await _repositoryWrapper.citizenRepositry.GetAll<CitizenDto>( );
            if (Citizens == null)
            {
                return (new List<CitizenDto>(), totalCount, "Error fetching citizens.");
            }

            var citizenDtos = _mapper.Map<List<CitizenDto>>(Citizens);

            return (citizenDtos, totalCount, null);
        }

        public async Task<(Citizen citizens, string? error)> update(UpdateCitizen updateCitizen, int id)
        {
            var citizen = await _repositoryWrapper.citizenRepositry.GetById(id);
            if (citizen == null)
            {
                return (null, "citizen not found");
            }
            citizen.Name = updateCitizen.Name;
            citizen.Phonenumber = updateCitizen.phoneNumber;
            
          
            var response = await _repositoryWrapper.citizenRepositry.Update(citizen);
            return response == null ? (null, "citizen could not be updated") : (citizen, null);
        }
    }
}
