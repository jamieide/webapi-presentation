using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StacksOfWax.Models;

namespace StacksOfWax.DataAccess
{
    public class StacksOfWaxDbContext : DbContext
    {
        public StacksOfWaxDbContext()
        {
            Database.SetInitializer(new StacksOfWaxDbInitializer());
        }

        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(c => c.IsUnicode(false).HasMaxLength(200));
        }
    }
}