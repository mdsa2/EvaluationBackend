using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.Interface;
using EvaluationBackend.Repository;

namespace EvaluationBackend.Respository
{
    public class characterRepositry:GenericRepository<Character,int>,ICharacterRepositry
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public characterRepositry(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;


        }
    }
}
