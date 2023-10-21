using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IProductServiceWithDto:IServiceWithDto<Product,ProductDTO>
    {
        Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductsWithCategory();
        Task<CustomResponseDTO<ProductDTO>> AddAsync(ProductCreateDto dto);
        Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(ProductUpdateDTO dto);


    }
}
