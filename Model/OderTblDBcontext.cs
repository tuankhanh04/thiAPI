using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class OderTblDBcontext : DbContext
    {
        public OderTblDBcontext()
        {
        }

        public OderTblDBcontext(DbContextOptions<OderTblDBcontext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PMFTL9B\\SQLEXPRESS01;Initial Catalog=OderSystem;User ID=sa;Password=1234567;Encrypt=False");
        }

        public DbSet<OderTbl> Orders { get; set; }
    }
}
