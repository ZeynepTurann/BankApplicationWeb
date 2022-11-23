using BankApp.MVC.Infrastructures.Context;
using BankApp.MVC.Infrastructures.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.MVC.Infrastructures.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class,new()
    {
        private readonly BankContext _context;

        public GenericRepository(BankContext context)
        {
            _context = context;
        }

        public async Task Create(T entity) //T benim bütün entity lerimin tipi olabilir(ApplicationUser vrya account yani context in içinde DbSet ile giden tüm entitylerim)
        {
           await _context.Set<T>().AddAsync(entity);

        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.SaveChanges();  //  inside the unitofwork 
        }
        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
