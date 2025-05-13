using server_hatde.Entities;

namespace server_hatde.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task<bool> AddServiceAsync(Service service);
        Task<bool> RemoveServiceAsync(int id);
        Task<bool> UpdateServiceAsync(Service service);
    }
}
