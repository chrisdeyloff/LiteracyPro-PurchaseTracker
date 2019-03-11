using System.Data.Entity;

using Autofac;
using EntityFramework.Toolkit;
using PurchaseTracker.DataAccess.Context;
using PurchaseTracker.DataAccess.Contracts.Repository;
using PurchaseTracker.DataAccess.Repository;
using PurchaseTracker.DataAccess.Seed;

namespace PurchaseTracker.DataAccess.Modularity
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register all data seeds:
            builder.RegisterType<CategoryDataSeed>().As<IDataSeed>().SingleInstance();
            builder.RegisterType<TransactionDataSeed>().As<IDataSeed>().SingleInstance();

            // Register an IDbConnection and an IDatabaseInitializer which are used to be injected into PurchaseTrackerContext
            builder.RegisterType<PurchaseTrackerContextDbConnection>().As<IDbConnection>().SingleInstance();
            builder.RegisterType<PurchaseTrackerContextDatabaseInitializer>().As<IDatabaseInitializer<PurchaseTrackerContext>>().SingleInstance();

            // Finally, register the context all the repositories as InstancePerDependency
            builder.RegisterType<PurchaseTrackerContext>().As<IPurchaseTrackerContext>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerDependency();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>().InstancePerDependency();
        }
    }
}
