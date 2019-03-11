using System;
using System.Linq.Expressions;
using EntityFramework.Toolkit;
using PurchaseTracker.Model;

namespace PurchaseTracker.DataAccess.Seed
{
    internal sealed class TransactionDataSeed : DataSeedBase<Transaction>
    {
        public override Expression<Func<Transaction, object>> AddOrUpdateExpression
        {
            get
            {
                return transaction => transaction.Id;
            }
        }

        public override Transaction[] GetAll()
        {
            return new[]
            {
                new Transaction {
                    Id = 1,
                    CategoryId = 1,
                    PayeeName = "Wells Fargo",
                    PurchaseAmount = 1000.00m,
                    PurchaseDate = DateTime.Parse("3/1/2018"),
                    Memo = "Monthly mortgage payment",
                    CreatedDate = DateTime.UtcNow
                },
                new Transaction {
                    Id = 2,
                    CategoryId = 2,
                    PayeeName = "Power Company",
                    PurchaseAmount = 123.00m,
                    PurchaseDate = DateTime.Parse("3/15/2018"),
                    Memo = "Monthly electric bill",
                    CreatedDate = DateTime.UtcNow
                },
                new Transaction {
                    Id = 3,
                    CategoryId = 3,
                    PayeeName = "Whole Foods",
                    PurchaseAmount = 329.53m,
                    PurchaseDate = DateTime.Parse("3/30/2018"),
                    Memo = "Weekly groceries",
                    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}
