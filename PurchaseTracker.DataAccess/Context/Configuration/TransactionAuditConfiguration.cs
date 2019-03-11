using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityFramework.Toolkit.Auditing;

using PurchaseTracker.Model.Auditing;

namespace PurchaseTracker.DataAccess.Context.Configuration
{
    public class TransactionAuditConfiguration : AuditEntityTypeConfiguration<TransactionAudit, int>
    {
        public TransactionAuditConfiguration()
        {
            this.Property(e => e.Id).IsRequired();
            this.Property(e => e.CategoryId).IsRequired();
            this.Property(e => e.PayeeName).IsRequired();
            this.Property(e => e.PurchaseAmount).IsRequired();
            this.Property(e => e.PurchaseDate).IsRequired();
            this.Property(e => e.Memo).IsOptional();

            this.ToTable(nameof(TransactionAudit));
        }
    }
}
