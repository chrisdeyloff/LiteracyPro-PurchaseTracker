using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Toolkit.Auditing;

namespace PurchaseTracker.Model.Auditing
{
    public class CategoryAudit : AuditEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
