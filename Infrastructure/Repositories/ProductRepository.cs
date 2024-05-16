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
    public class ProductRepository : IProductRepository
    {
        private readonly LarixContext _context;

        public ProductRepository(LarixContext context)
        {
            _context =  context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(int id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
        }
        public Product Add(Product product)
        {
            
            product.Created = DateTime.UtcNow;
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Update(Product product)
        {
            product.LastModified = DateTime.UtcNow;
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

    }
}
