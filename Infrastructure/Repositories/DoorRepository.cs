using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DoorRepository : IDoorRepository
    {
        private readonly LarixContext _context;

        public DoorRepository(LarixContext context)
        {
            _context =  context;
        }

        public async Task<IEnumerable<Door>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Doors.Skip((pageNumber - 1)* pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetAllCountAsync()
        {
            return await  _context.Doors.CountAsync();
        }

        public async Task<Door> GetByIdAsync(int id)
        {
            return await _context.Doors.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Door> AddAsync(Door door)
        {
            
            //window.Created = DateTime.UtcNow;
            var createdWindow = await _context.Doors.AddAsync(door);
            await _context.SaveChangesAsync();
            return createdWindow.Entity;
        }

        public async Task UpdateAsync(Door door)
        {
           //window.LastModified = DateTime.UtcNow;
            _context.Doors.Update(door);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(Door door)
        {
            _context.Doors.Remove(door);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;    
        }


    }
}
