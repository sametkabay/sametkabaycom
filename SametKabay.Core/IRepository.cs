using System.Linq;
using System.Threading.Tasks;
using SametKabay.Core.Models;

namespace SametKabay.Core
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity, object key);
        Task Delete(T entity);
        Task DeleteById(int id);
        Task Remove(T entity);
        void SaveChanges();
    }
}