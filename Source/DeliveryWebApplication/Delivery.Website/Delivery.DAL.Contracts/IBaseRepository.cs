using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllAsync();
        T Get(int id);
        Task<T> GetAsync(int id);
        void Create(T item);
        Task CreateAsync(T item);
        void Update(T item);
        Task UpdateAsync(T item);
        void Delete(int id);
        Task DeleteAsync(int id);
    }
}