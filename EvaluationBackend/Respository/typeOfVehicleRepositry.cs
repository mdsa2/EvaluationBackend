using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.Interface;
using EvaluationBackend.Repository;

namespace EvaluationBackend.Respository
{
    public class typeOfVehicleRepositry:GenericRepository<TypeOfVehicles, int>,ItypeOfVehicleRepositry
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public typeOfVehicleRepositry(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
