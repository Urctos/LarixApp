using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
