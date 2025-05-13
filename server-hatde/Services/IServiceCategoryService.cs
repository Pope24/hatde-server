using server_hatde.Entities;

namespace server_hatde.Services
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync();
        Task<ServiceCategory> GetServiceCategoryByIdAsync(int id);
    }
}