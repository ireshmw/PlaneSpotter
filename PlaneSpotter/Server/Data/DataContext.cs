using Microsoft.EntityFrameworkCore;

namespace PlaneSpotter.Server.Data
{
    public class DataContext: DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SightRecord>().HasData(
                new SightRecord
                {
                     Id = 1,
                     Make = "Boeing",
                     Model = "777-300ER",
                     Registration = "G-RNAC",
                     Location = "London Gatwick",
                     DateTime = DateTime.Now
                }              
                );
        }

        public DbSet<SightRecord> SightRecords { get; set; }

    }
}
