using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDoorRepository
    {
        Task <IEnumerable<Door>> GetAllAsync(int pageNumber, int pageSize);
        Task<int> GetAllCountAsync();
        Task<Door> GetByIdAsync(int id);
        Task<Door> AddAsync(Door door);
        Task UpdateAsync(Door door);
        Task DeleteAsync(Door door);
    }
}
