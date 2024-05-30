using Application.Dto.GlassTypesDto;
using Application.Dto.WindowsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaceas
{
    public interface IGlassTypeService
    {
        IEnumerable<GlassTypeDto> GetAllGlassTypes();
        GlassTypeDto GetGlassTypeById(int id);

        GlassTypeDto AddNewGlassType(CreateGlassTypeDto product);

        void UpdateGlassType(UpdateGlassTypeDto updateProduct);

        void DeleteWGlassType(int id);
    }
}
