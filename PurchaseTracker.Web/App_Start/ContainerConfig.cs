using System.Reflection;
using System.Web.Mvc;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using PurchaseTracker.BusinessLogic;
using PurchaseTracker.BusinessLogic.Contracts;
using PurchaseTracker.DataAccess.Context;
using PurchaseTracker.DataAccess.Repository;
using PurchaseTracker.DataAccess.Contracts.Repository;
using EntityFramework.Toolkit;

namespace PurchaseTracker.Web
{
    public class ContainerConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            // register controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<PurchaseTrackerContextDbConnection>().As<IDbConnection>().InstancePerRequest();
            builder.RegisterType<PurchaseTrackerContext>().As<IPurchaseTrackerContext>().InstancePerRequest();
            // register services
            builder.RegisterType<CategoryLogic>().As<ICategoryLogic>().InstancePerRequest();
            builder.RegisterType<TransactionLogic>().As<ITransactionLogic>().InstancePerRequest();

            // register repositories
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerRequest();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>().InstancePerRequest();
            //builder.RegisterGeneric(typeof(RepositoryBase<SchoolDetail>)).As(typeof(IRepository<SchoolDetail>));

            // build and setup resolver
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}