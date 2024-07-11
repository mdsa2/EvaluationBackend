using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.Interface;
using EvaluationBackend.Repository;

namespace EvaluationBackend.Respository
{
    public class PlaceFineRepositry: GenericRepository<PlaceFine,int>,IPlaceFineRepositry
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PlaceFineRepositry(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
