using Application.Dto.WindowsDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaceas
{
    public interface IWindowService
    {
        IEnumerable<WindowDto> GetAllWindows();
        WindowDto GetWindowById(int id);

        WindowDto AddNewWindow(CreateWindowDto product);

        void UpdateWindow(UpdateWindowDto updateProduct);

        void DeleteWindow(int id);
    }
}
