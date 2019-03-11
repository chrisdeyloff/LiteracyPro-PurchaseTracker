using EntityFramework.Toolkit;

using PurchaseTracker.DataAccess.Context;
using PurchaseTracker.DataAccess.Contracts.Repository;
using PurchaseTracker.Model;

namespace PurchaseTracker.DataAccess.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IPurchaseTrackerContext context)
            : base(context)
        {
        }
    }
}
