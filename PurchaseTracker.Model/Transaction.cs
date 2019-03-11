using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Toolkit.Auditing;

namespace PurchaseTracker.Model
{
    [DebuggerDisplay("Transaction: Id={Id}, Category={Category?.Name}, PayeeName={PayeeName}, PurchaseAmount={PurchaseAmount.ToString(\"C\", System.Globalization.CultureInfo.CurrentCulture)}, PurchaseDate={PurchaseDate.ToString(\"G\")}, Memo={Memo}, CreatedDate={CreatedDate.ToString(\"O\")}, UpdatedDate={UpdatedDate?.ToString(\"O\")}")]
    public class Transaction : ICreatedDate, IUpdatedDate
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string PayeeName { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Memo { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
