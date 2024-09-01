using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data
{
    public class ApplecationDBContex : DbContext
    {
        public ApplecationDBContex(DbContextOptions<ApplecationDBContex> options)
      : base(options)
        {
        }
        public DbSet<User> users { get; set; }
    }
}
