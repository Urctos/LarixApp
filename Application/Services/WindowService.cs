using Application.Dto.WindowsDto;
using Application.Interfaceas;
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
    public class WindowService : IWindowService
    {
        private readonly IWindowRepository _windowRepository;
        private readonly IMapper _mapper;
        public WindowService(IWindowRepository windowRepository, IMapper mapper)
        {
            _windowRepository = windowRepository;
            _mapper = mapper;
        }

        public IEnumerable<WindowDto> GetAllWindows()
        {
            var windows = _windowRepository.GetAll();
            return _mapper.Map<IEnumerable<WindowDto>>(windows);
        }

        public WindowDto GetWindowById(int id)
        {
            var window = _windowRepository.GetById(id);
            return _mapper.Map<WindowDto>(window);
            
            
        }

        public WindowDto AddNewWindow(CreateWindowDto newWindow)
        {
            if(string.IsNullOrEmpty(newWindow.Name))
            {
                throw new Exception("Product can't have an empty title");
            }

            var window = _mapper.Map<Window>(newWindow);
            _windowRepository.Add(window);
            return _mapper.Map<WindowDto>(window);

        }

        public void UpdateWindow(UpdateWindowDto updateWindow)
        {
            var existingWindow = _windowRepository.GetById(updateWindow.Id);
            var window = _mapper.Map(updateWindow, existingWindow);
            _windowRepository.Update(window);
        }

        public void DeleteWindow(int id)
        {
            var window = _windowRepository.GetById(id);
            _windowRepository.Delete(window);
        }
    }
}
