using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaceas
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);

        ProductDto AddNewProduct(CreateProductDto product);

        void UpdateProduct(UpdateProductDto updateProduct);

        void DeleteProduct(int id);
    }
}
