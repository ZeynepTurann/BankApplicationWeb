using BankApp.MVC.Infrastructures.Context;
using BankApp.MVC.Infrastructures.Interfaces;
using BankApp.MVC.Infrastructures.Repositories;
using System.Threading.Tasks;

namespace BankApp.MVC.Infrastructures.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankContext _context;

        public UnitOfWork(BankContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> GetRepository<T>() where T : class, new()
        {
           return new GenericRepository<T>(_context);
        }

        public async Task SaveChanges()
        {
           await _context.SaveChangesAsync();
        }
    }
}
