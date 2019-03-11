using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Toolkit.Auditing;

namespace PurchaseTracker.Model.Auditing
{
    public class TransactionAudit : AuditEntity
    {
        public virtual int Id { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string PayeeName { get; set; }
        public virtual decimal PurchaseAmount { get; set; }
        public virtual DateTime PurchaseDate { get; set; }
        public virtual string Memo { get; set; }
    }
}
