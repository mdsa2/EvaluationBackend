using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.Interface;
using EvaluationBackend.Repository;

namespace EvaluationBackend.Respository
{
    public class FineTypeRepositry:GenericRepository<FineTypes,int>,IFineTypeRepositry
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public FineTypeRepositry(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
