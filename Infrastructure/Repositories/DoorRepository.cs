using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class DoorRepository : IDoorRepository
    {
        private readonly LarixContext _context;

        public DoorRepository(LarixContext context)
        {
            _context = context;
        }

    }
}
