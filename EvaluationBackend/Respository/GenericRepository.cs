using System.Data.Common;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EvaluationBackend.Utils;
using EvaluationBackend.DATA;
using EvaluationBackend.Entities;
using EvaluationBackend.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EvaluationBackend.Repository
{
    public class GenericRepository<T,TId> : IGenericRepository<T,TId> where T : BaseEntity<TId>
    {
        protected readonly DataContext _dbContext;
        protected readonly IMapper _mapper;

        protected GenericRepository(DataContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        
        public async Task<T> GetById(TId id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
  
        
        public async Task<(List<TDto> data, int totalCount)> GetAll<TDto>(int pageNumber = 0, int pageSize = 10)
        {
            var query = _dbContext.Set<T>().AsNoTracking();
            return await ExecuteQuery<TDto>(query, pageNumber, pageSize);
        }

        public async Task<(List<TDto> data, int totalCount)> GetAll<TDto>(Expression<Func<T, bool>> predicate, int pageNumber = 0, int pageSize = 10)
        {
            var query = _dbContext.Set<T>().AsNoTracking().Where(predicate);
            return await ExecuteQuery<TDto>(query, pageNumber, pageSize);
        }

        private async Task<(List<TDto> data, int totalCount)> ExecuteQuery<TDto>(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var data = pageNumber == 0
            ? await query.ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync()
            : await query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync();

            return (data, totalCount);
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            try{
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
                 return null;
            }
            return entity;
        }

        public async Task<T> Delete(TId id)
        {
            var result = await GetById(id);
            if(result == null) return null;
            _dbContext.Set<T>().Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<T> Update(T entity)
        {
             _dbContext.Set<T>().Update(entity);
             try{
                 await _dbContext.SaveChangesAsync();

             }
             catch(Exception e){
                 Console.WriteLine(e.Message);
                 return null;
             }
            return entity;
        }
        
       
        
        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            var entity = await _dbContext.Set<T>()
            .AsNoTracking()
            .Where(predicate)
            .FirstOrDefaultAsync();

            return entity;
        }

        public async Task<TDto?> Get<TDto>(Expression<Func<T, bool>> predicate)
        {
            var entity = await _dbContext.Set<T>()
            .AsNoTracking()
            .Where(predicate)
            .ProjectTo<TDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

            return entity;
        }
        
        public async Task<T> Get(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include
        ) {
            var query = _dbContext.Set<T>()
            .AsQueryable();
            query = predicate != null ? query.Where(predicate) : query;
            if (include != null) query = include(query);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> Get(Func<IQueryable<T>, IIncludableQueryable<T, object>> include) =>
        await Get(null, include);
        
        public async Task<(List<T> data, int totalCount)> GetAll(int pageNumber = 0,int pageSize = 10)
        {
            return  await GetAll(null, null, pageNumber,pageSize);
        }
        public async Task<(List<T> data, int totalCount)> GetAll(Expression<Func<T, bool>> predicate, int pageNumber = 0,int pageSize = 10)
        {
            return await GetAll(predicate, null, pageNumber,pageSize);
        }
        public async Task<(List<T> data, int totalCount)> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include, int pageNumber = 0,int pageSize = 10)
        {
            return await GetAll(null, include, pageNumber,pageSize);
        }
        public async Task<(List<T> data, int totalCount)> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, int pageNumber = 0,int pageSize = 10)
        {
            var query = predicate == null
            ? _dbContext.Set<T>()
            : _dbContext.Set<T>()
            .Where(predicate);
            query = include != null ? include(query) : query;
            query = query.OrderByDescending(model => model.CreationDate);
            return (await (pageNumber == 0
            ? query.ToListAsync()
            : query.Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync()),
            await query.CountAsync());
        }


    }
}