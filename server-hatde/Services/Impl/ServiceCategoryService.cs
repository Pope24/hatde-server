using Microsoft.EntityFrameworkCore;
using server_hatde.Entities;

namespace server_hatde.Services.Impl
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly WeddingDbContext _dbContext;

        public ServiceCategoryService(WeddingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync()
        {
            var categories = await _dbContext.ServiceCategories.ToListAsync();
            return categories;
        }

        public async Task<ServiceCategory> GetServiceCategoryByIdAsync(int id)
        {
            var category = await _dbContext.ServiceCategories.FirstOrDefaultAsync(s => s.ServiceCategoryId == id);
            return category;
        }
    }
}
