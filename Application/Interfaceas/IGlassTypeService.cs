using Application.Dto.GlassTypesDto;

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
