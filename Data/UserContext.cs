using Microsoft.EntityFrameworkCore;
using SimpleUserAPI.Models;

namespace SimpleUserAPI.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}



