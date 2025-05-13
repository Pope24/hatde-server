using Microsoft.EntityFrameworkCore;
using server_hatde.Entities;

namespace server_hatde.Services.Impl
{
    public class ServiceService : IServiceService
    {
        private readonly WeddingDbContext _context;

        public ServiceService(WeddingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddServiceAsync(Service service)
        {
            await _context.AddAsync(service);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.ServiceId == id);
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<bool> RemoveServiceAsync(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.ServiceId == id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateServiceAsync(Service service)
        {
            _context.Update(service);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
