using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.Interface;
using EvaluationBackend.Repository;

namespace EvaluationBackend.Respository
{
    public class VehicleCityRepositry:GenericRepository<VehiclesCity,int>, IVehicleCityRepositry
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public VehicleCityRepositry(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
