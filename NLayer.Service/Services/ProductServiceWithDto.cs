using AutoMapper;
using Microsoft.AspNetCore.Http;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductServiceWithDto : ServiceWithDto<Product, ProductDTO>, IProductServiceWithDto
    {
        private readonly IProductRepository _productRepository;
        public ProductServiceWithDto(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork, mapper)
        {
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDTO<ProductDTO>> AddAsync(ProductCreateDto dto)
        {
           var newEntity = _mapper.Map<Product>(dto);   
            await _productRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();

            var newDto =_mapper.Map<ProductDTO>(newEntity);
            return CustomResponseDTO<ProductDTO>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();

            var productsDto= _mapper.Map<List<ProductWithCategoryDTO>>(products);   
            return CustomResponseDTO<List<ProductWithCategoryDTO>>.Success(200, productsDto);
        }

        public async Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(ProductUpdateDTO dto)
        {
           var product = _mapper.Map<Product>(dto);
           _productRepository.Update(product);
            await _unitOfWork.CommitAsync();

            return CustomResponseDTO<NoContentDTO>.Success(StatusCodes.Status204NoContent);
        }
    }
}
