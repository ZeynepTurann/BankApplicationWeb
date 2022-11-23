using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.MVC.Infrastructures.Interfaces
{
    public interface IGenericRepository<T> where T : class,new()
    {
        Task Create(T entity);
        void Remove(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        void Update(T entity);

        IQueryable<T> GetQueryable();
    }
}
