using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PanPanBakery.Models;
using PanPanBakerys.Models;

namespace PanPanBakerys.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PanPanBakery.Models.CakeBookings>? CakeBookings { get; set; }
        public DbSet<PanPanBakerys.Models.Homepage>? Homepage { get; set; }
        public DbSet<PanPanBakerys.Models.User>? User { get; set; }
    }
}