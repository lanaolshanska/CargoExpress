using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.BL.Contracts
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        Task DeleteAsync(int id);
    }
}