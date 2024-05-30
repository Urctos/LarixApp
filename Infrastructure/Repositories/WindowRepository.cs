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
    public class WindowRepository : IWindowRepository
    {
        private readonly LarixContext _context;

        public WindowRepository(LarixContext context)
        {
            _context =  context;
        }

        public IEnumerable<Window> GetAll()
        {
            return _context.Windows;
        }

        public Window GetById(int id)
        {
            return _context.Windows.SingleOrDefault(x => x.Id == id);
        }
        public Window Add(Window window)
        {
            
            window.Created = DateTime.UtcNow;
            _context.Windows.Add(window);
            _context.SaveChanges();
            return window;
        }

        public void Update(Window window)
        {
           window.LastModified = DateTime.UtcNow;
            _context.Windows.Update(window);
            _context.SaveChanges();
        }
        public void Delete(Window window)
        {
            _context.Windows.Remove(window);
            _context.SaveChanges();
        }

    }
}
