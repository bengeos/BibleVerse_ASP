using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BibleVerse.Web.Models.Mapping
{
    public class VerseMap : EntityTypeConfiguration<Verse>
    {
        public VerseMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Body)
                .IsRequired();

            this.Property(t => t.Verse1)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Verse");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.Verse1).HasColumnName("Verse");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Verses)
                .HasForeignKey(d => d.CategoryID);

        }
    }
}
