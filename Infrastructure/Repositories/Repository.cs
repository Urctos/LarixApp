using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
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

        //public async Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        //{
        //    return await _context.Set<T>()
        //        .Where(m => m.Title.ToLower().Contains(filterBy.ToLower()) || m.Content.ToLower().Contains(filterBy.ToLower()))
        //        .OrderByPropertyName(sortField, ascending)
        //        .Skip((pageNumber - 1) * pageSize).Take(pageSize)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        {
            IQueryable<T> query = _context.Set<T>();

            // Dynamiczne filtrowanie
            if (!string.IsNullOrEmpty(filterBy))
            {
                var properties = typeof(T).GetProperties()
                    .Where(p => p.PropertyType == typeof(string))
                    .Select(p => p.Name)
                    .ToList();

                var filterExpression = ExtensionMethod.GenerateFilterExpression<T>(properties, filterBy);
                query = query.Where(filterExpression);
            }

            // Dynamiczne sortowanie
            query = query.OrderByPropertyName(sortField, ascending);

            // Paginacja
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<int> GetAllCountAsync(string filterBy)
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
