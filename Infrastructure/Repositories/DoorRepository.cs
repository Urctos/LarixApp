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
            _context = context;
        }

    }
}
