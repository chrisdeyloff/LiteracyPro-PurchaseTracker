using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using PurchaseTracker.Model;

namespace PurchaseTracker.DataAccess.Context.Configuration
{
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            this.HasKey(d => d.Id);

            this.Property(e => e.CategoryId).IsRequired();
            this.Property(e => e.PayeeName).IsRequired();
            this.Property(e => e.PurchaseAmount).IsRequired();
            this.Property(e => e.PurchaseDate).IsRequired();
            this.Property(e => e.Memo).IsOptional();

            this.HasRequired(t => t.Category)
                .WithMany()
                .HasForeignKey(d => d.CategoryId);

            this.Property(e => e.CreatedDate).IsRequired();
            this.Property(e => e.UpdatedDate).IsOptional();

            this.Property(e => e.RowVersion)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .HasMaxLength(8)
                .IsRowVersion()
                .IsRequired();

            this.ToTable(nameof(Transaction));
        }
    }
}
