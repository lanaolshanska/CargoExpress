using Delivery.BL.Contracts;
using Delivery.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.BL
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<T> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public T GetById(int id)
        {
            return _repository.Get(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public void Create(T item)
        {
            _repository.Create(item);
        }
        
        public void Update(T item)
        {
            _repository.Update(item);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}