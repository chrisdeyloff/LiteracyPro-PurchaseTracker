using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityFramework.Toolkit.Auditing;

using PurchaseTracker.Model.Auditing;

namespace PurchaseTracker.DataAccess.Context.Configuration
{
    public class CategoryAuditConfiguration : AuditEntityTypeConfiguration<CategoryAudit, int>
    {
        public CategoryAuditConfiguration()
        {
            this.Property(e => e.Id).IsRequired();
            this.Property(e => e.Name).IsRequired();

            this.ToTable(nameof(CategoryAudit));
        }
    }
}
