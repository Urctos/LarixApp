using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IWindowRepository
    {
        IEnumerable<Window> GetAll();
        Window GetById(int id);
        Window Add(Window window);
        void Update(Window window);
        void Delete(Window window);
    }
}
