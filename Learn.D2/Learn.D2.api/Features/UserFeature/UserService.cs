using Learn.D2.Database;
using Learn.D2.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace Learn.D2.api.Features.UserFeature
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.AsNoTracking().ToListAsync();
            return users;
        }
    }
}
