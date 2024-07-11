using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.Interface;
using EvaluationBackend.Repository;

namespace EvaluationBackend.Respository
{
    public class GovRepositry : GenericRepository<Gov, int>, IGovRepositry
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public GovRepositry(DataContext context, IMapper mapper):base(context,mapper)        {
            _context = context;
            mapper=_mapper;


        }

    }
}
