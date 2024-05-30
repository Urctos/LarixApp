using Application.Dto.GlassTypesDto;
using Application.Dto.WindowsDto;
using Application.Interfaceas;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GlassTypeService : IGlassTypeService
    {
        private readonly IGlassTypeRepository _glassTypeRepository;
        private readonly IMapper _mapper;

        public GlassTypeService(IGlassTypeRepository glassTypeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _glassTypeRepository = glassTypeRepository; 
        }

        public IEnumerable<GlassTypeDto> GetAllGlassTypes()
        {
            var glassTypes = _glassTypeRepository.GetAllGlassTypes();
            return _mapper.Map<IEnumerable<GlassTypeDto>>(glassTypes);
        }

        public GlassTypeDto GetGlassTypeById(int id)
        {
            var glassType = _glassTypeRepository.GetGlassTypeId(id);
            return _mapper.Map<GlassTypeDto>(glassType);
        }

        public GlassTypeDto AddNewGlassType(CreateGlassTypeDto newGlassType)
        {

            if (string.IsNullOrEmpty(newGlassType.Name))
            {
                throw new Exception("GlassType can't have an empty title");
            }

            var glassType = _mapper.Map<GlassType>(newGlassType);
            _glassTypeRepository.AddGlassType(glassType);
            return _mapper.Map<GlassTypeDto>(glassType);
        }

        public void UpdateGlassType(UpdateGlassTypeDto updateGlassType)
        {
            var existGlassType = _glassTypeRepository.GetGlassTypeId(updateGlassType.GlassTypeId);
            var glassType = _mapper.Map(updateGlassType, existGlassType);
            _glassTypeRepository.UpdateGlassType(glassType);
        }

        public void DeleteWGlassType(int id)
        {
            var glassType = _glassTypeRepository.GetGlassTypeId(id);
            _glassTypeRepository.DeleteGLassType(glassType);
        }
    }
}
