using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GlassTypeRepository : IGlassTypeRepository
    {
        private readonly LarixContext _context;

        public GlassTypeRepository( LarixContext context)
        {
            _context = context;
        }
    }
}
