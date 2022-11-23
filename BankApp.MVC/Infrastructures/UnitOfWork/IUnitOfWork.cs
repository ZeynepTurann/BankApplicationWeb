using BankApp.MVC.Infrastructures.Interfaces;
using System.Threading.Tasks;

namespace BankApp.MVC.Infrastructures.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChanges();
    }
}
