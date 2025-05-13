using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_hatde.Services;

namespace server_hatde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IServiceCategoryService categoryService;

        public ServiceCategoryController(IServiceCategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryService.GetServiceCategoriesAsync();
            return Ok(categories);
        }
    }
}
