using System.Collections.Generic;
using System.Data.Entity.Migrations;
using EntityFramework.Toolkit;
using EntityFramework.Toolkit.Auditing;
using EntityFramework.Toolkit.Extensions;
using PurchaseTracker.DataAccess.Context;
using PurchaseTracker.DataAccess.Seed;

namespace PurchaseTracker.DataAccess.Migrations
{
    internal class PurchaseTrackerContextMigrationConfiguration : DbMigrationsConfiguration<PurchaseTrackerContext>
    {
        private readonly IEnumerable<IDataSeed> dataSeeds;

        public PurchaseTrackerContextMigrationConfiguration() : this(new IDataSeed[] {
            new CategoryDataSeed(),
            new TransactionDataSeed()
        })
        {
        }

        public PurchaseTrackerContextMigrationConfiguration(IEnumerable<IDataSeed> dataSeeds)
        {
            this.AutomaticMigrationsEnabled = true;
            //this.AutomaticMigrationsEnabled = false;

            this.dataSeeds = dataSeeds;
        }

        protected override void Seed(PurchaseTrackerContext context)
        {
            context.Seed(this.dataSeeds);
        }
    }
}
