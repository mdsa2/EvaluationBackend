using AutoMapper;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.Interface;

namespace EvaluationBackend.Repository
{
    public class ArticleRepositry : GenericRepository<Article,int>, IArticleRespository
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public ArticleRepositry(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}