using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class SigortaIslemleriContext : DbContext 
    {
        public SigortaIslemleriContext(DbContextOptions<SigortaIslemleriContext> options) 
            : base(options) {

        }

        public DbSet<SigortaIslemleri> Bilgiler { get; set; } = null!;
        public DbSet<PoliceModel> Policeler { get; set; } = null!;

        public DbSet<Dask> Dask { get; set; } = null!;
        public DbSet<Kasko> Kasko { get; set; } = null!;
        public DbSet<Trafik> Trafik { get; set; } = null!;
        public DbSet<Saglik> Saglik { get; set; } = null!;

    }
}
