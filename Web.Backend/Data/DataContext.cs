using Microsoft.EntityFrameworkCore;
using Web.Backend.Models;

namespace Web.Backend.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
