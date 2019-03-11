using System.Data.Entity;

using PurchaseTracker.DataAccess.Context;
using PurchaseTracker.DataAccess.Migrations;

namespace PurchaseTracker.DataAccess
{
    internal sealed class PurchaseTrackerContextDatabaseInitializer : MigrateDatabaseToLatestVersion<PurchaseTrackerContext, PurchaseTrackerContextMigrationConfiguration>
    {
        public PurchaseTrackerContextDatabaseInitializer()
        {
        }

        public PurchaseTrackerContextDatabaseInitializer(PurchaseTrackerContextMigrationConfiguration migrationConfiguration)
            : base(useSuppliedContext: true,
                configuration: migrationConfiguration)
        {
        }
    }
}
