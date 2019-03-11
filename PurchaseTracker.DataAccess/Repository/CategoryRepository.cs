using EntityFramework.Toolkit;

using PurchaseTracker.DataAccess.Context;
using PurchaseTracker.DataAccess.Contracts.Repository;
using PurchaseTracker.Model;

namespace PurchaseTracker.DataAccess.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IPurchaseTrackerContext context)
            : base(context)
        {
        }
    }
}
