using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Toolkit.Auditing;

namespace PurchaseTracker.Model
{
    [DebuggerDisplay("Category: Id={Id}, Name={Name}, CreatedDate={CreatedDate}, UpdatedDate={UpdatedDate}")]
    public class Category : ICreatedDate, IUpdatedDate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
