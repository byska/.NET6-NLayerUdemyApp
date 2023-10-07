using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System.Linq.Expressions;

namespace NLayer.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _uow;
        public Service(IGenericRepository<T> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _uow.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _uow.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression) => await _repository.AnyAsync(expression);


        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAll().ToListAsync();


        public async Task<T> GetByIdAsync(int id)
        {
            var has = await _repository.GetByIdAsync(id);
            if (has == null)
            {
                throw new NotFoundException($"{typeof(T).Name}({id}) does not exist");
            }
            return has;
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _uow.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _uow.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _uow.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
