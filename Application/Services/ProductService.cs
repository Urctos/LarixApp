using Application.Dto;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductDto>(product);
            
            
        }

        public ProductDto AddNewProduct(CreateProductDto newProduct)
        {
            if(string.IsNullOrEmpty(newProduct.Name))
            {
                throw new Exception("Product can't have an empty title");
            }

            var product = _mapper.Map<Product>(newProduct);
            _productRepository.Add(product);
            return _mapper.Map<ProductDto>(product);

        }

        public void UpdateProduct(UpdateProductDto updateProduct)
        {
            var existingProduct = _productRepository.GetById(updateProduct.Id);
            var product = _mapper.Map(updateProduct, existingProduct);
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Delete(product);
        }
    }
}
