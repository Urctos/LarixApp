using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LarixContext _context;

        public Repository(LarixContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetAllCountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> AddAsync(T entity)
        {

            //window.Created = DateTime.UtcNow;
            var createdEntity = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task UpdateAsync(T entity)
        {
            //window.LastModified = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
