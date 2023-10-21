using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryWithDtoController : CustomBaseController
    {
        private readonly IServiceWithDto<Category, CategoryDTO> _service;
        public CategoryWithDtoController(IServiceWithDto<Category,CategoryDTO> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO category)
        {
            return CreateActionResult(await _service.AddAsync(category));
        }
    }
}
