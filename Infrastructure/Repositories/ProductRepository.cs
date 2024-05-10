using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly ISet<Product> _products = new HashSet<Product>()
        {
            new (1, "Title 1", "Description 1", 115, 150, GlassType.SinglePane),
            new (2, "Title 2", "Description 2", 120, 155, GlassType.SinglePane),
            new (3, "Title 3", "Description 3", 135, 156, GlassType.SinglePane),

        };
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.SingleOrDefault(x => x.Id == id);

        }
        public Product Add(Product product)
        {
            product.Id = _products.Count() + 1;
            product.Created = DateTime.UtcNow;
            _products.Add(product);
            return product;
        }

        public void Update(Product product)
        {
            product.LastModified = DateTime.UtcNow;
        }
        public void Delete(Product product)
        {
            _products.Remove(product);
        }

    }
}
