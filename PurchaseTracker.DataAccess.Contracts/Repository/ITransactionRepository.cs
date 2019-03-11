using EntityFramework.Toolkit;
using PurchaseTracker.Model;

namespace PurchaseTracker.DataAccess.Contracts.Repository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }
}
