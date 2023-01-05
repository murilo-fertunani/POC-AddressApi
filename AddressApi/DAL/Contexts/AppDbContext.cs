using Microsoft.EntityFrameworkCore;
using AddressApi.DAL.Entities;

namespace AddressApi.DAL.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> Addresses { get; set; }
    }
}