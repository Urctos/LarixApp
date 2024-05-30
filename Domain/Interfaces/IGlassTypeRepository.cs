using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGlassTypeRepository
    {
        IEnumerable<GlassType> GetAllGlassTypes();
        GlassType GetGlassTypeId(int id);
        GlassType AddGlassType(GlassType gLassType);
        void UpdateGlassType(GlassType gLassType);
        void DeleteGLassType(GlassType gLassType);
    }
}
