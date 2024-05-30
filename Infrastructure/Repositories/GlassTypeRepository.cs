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

        public IEnumerable<GlassType> GetAllGlassTypes()
        {
            return _context.GlassTypes;
        }

        public GlassType GetGlassTypeId(int id)
        {
           return  _context.GlassTypes.SingleOrDefault(x => x.GlassTypeId == id);
        }
        public GlassType AddGlassType(GlassType gLassType)
        {
            gLassType.Created = DateTime.UtcNow;
            _context.GlassTypes.Add(gLassType);
            _context.SaveChanges();
            return gLassType;
        }
        public void UpdateGlassType(GlassType gLassType)
        {
            gLassType.LastModified = DateTime.UtcNow;
            _context.GlassTypes.Update(gLassType);
            _context.SaveChanges();
        }

        public void DeleteGLassType(GlassType gLassType)
        {
            _context.GlassTypes.Remove(gLassType);
            _context.SaveChanges();
        }
    }
}
