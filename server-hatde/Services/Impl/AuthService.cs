using Microsoft.EntityFrameworkCore;
using server_hatde.Entities;
using server_hatde.Requests;
using server_hatde.Responses;

namespace server_hatde.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly WeddingDbContext _context;

        public AuthService(WeddingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ExistPhone(string phone)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == phone);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<LoginReponse?> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);
            if (user == null)
            {
                return null;
            }
            return new LoginReponse()
            {
                Email = user.Email,
                Fullname = user.FullName,
                Role = user.Role,
                Address = user.Address,
                Phone = user.Phone
            };
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var user = new User()
            {
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone,
                FullName = request.Fullname,
                Address = request.Address,
                Role = request.Role,
                Status = "inactive",
                CreatedAt = DateTime.Now
            };
            var userAdded = await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            if (user.Role == "vendor")
            {
                await _context.AddAsync(new VendorProfile()
                {
                    VendorId = userAdded.Entity.UserId,
                    BusinessName = request.BusinessName,
                    Description = request.Description,
                    Mst = request.Mst
                });
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
