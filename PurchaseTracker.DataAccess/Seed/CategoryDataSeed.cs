using System;
using System.Linq.Expressions;
using EntityFramework.Toolkit;
using PurchaseTracker.Model;

namespace PurchaseTracker.DataAccess.Seed
{
    internal sealed class CategoryDataSeed : DataSeedBase<Category>
    {
        public override Expression<Func<Category, object>> AddOrUpdateExpression
        {
            get
            {
                return category => category.Id;
            }
        }

        public override Category[] GetAll()
        {
            return new[]
            {
                new Category { Id = 1, Name = "Mortgage", CreatedDate = DateTime.UtcNow },
                new Category { Id = 2, Name = "Electric", CreatedDate = DateTime.UtcNow },
                new Category { Id = 3, Name = "Groceries", CreatedDate = DateTime.UtcNow },
            };
        }
    }
}
