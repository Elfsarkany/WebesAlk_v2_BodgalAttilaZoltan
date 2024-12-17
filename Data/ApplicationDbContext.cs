using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebesAlk_v2_BodgalAttilaZoltan.Models;

namespace WebesAlk_v2_BodgalAttilaZoltan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebesAlk_v2_BodgalAttilaZoltan.Models.Character>? Characters { get; set; }
    }
}
