using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDTO<CategoryWithProductsDTO>> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
