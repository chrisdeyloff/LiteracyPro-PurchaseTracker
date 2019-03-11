using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using PurchaseTracker.Model;

namespace PurchaseTracker.DataAccess.Context.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.HasKey(d => d.Id);

            this.Property(e => e.Name).IsRequired();

            this.Property(e => e.CreatedDate).IsRequired();
            this.Property(e => e.UpdatedDate).IsOptional();

            this.Property(e => e.RowVersion)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .HasMaxLength(8)
                .IsRowVersion()
                .IsRequired();

            this.ToTable(nameof(Category));
        }
    }
}
