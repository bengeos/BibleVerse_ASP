using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BibleVerse.Web.Models.Mapping;

namespace BibleVerse.Web.Models
{
    public partial class BibleVerseDatabaseContext : DbContext
    {
        static BibleVerseDatabaseContext()
        {
            Database.SetInitializer<BibleVerseDatabaseContext>(null);
        }

        public BibleVerseDatabaseContext()
            : base("Name=BibleVerseDatabaseContext")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Verse> Verses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
 
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new VerseMap());
        }
    }
}
