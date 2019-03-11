using System;
using System.Data.Entity;
using EntityFramework.Toolkit;
using EntityFramework.Toolkit.Auditing;
using EntityFramework.Toolkit.Extensions;
using PurchaseTracker.Model;
using PurchaseTracker.Model.Auditing;
using PurchaseTracker.DataAccess.Context.Configuration;

namespace PurchaseTracker.DataAccess.Context
{
    public class PurchaseTrackerContext : AuditDbContextBase<PurchaseTrackerContext>, IPurchaseTrackerContext
    {
        private static readonly AuditDbContextConfiguration AuditDbContextConfiguration = new AuditDbContextConfiguration(auditEnabled: true, auditDateTimeKind: DateTimeKind.Utc);

        /// <summary>
        ///     Empty constructor is used for 'update-database' command-line command.
        /// </summary>
        public PurchaseTrackerContext() : base()
        {
            this.RegisterAuditTypes();
        }

        public PurchaseTrackerContext(IDbConnection dbConnection) : base(dbConnection, null)
        {
            this.RegisterAuditTypes();
        }

        public PurchaseTrackerContext(IDbConnection dbConnection, IDatabaseInitializer<PurchaseTrackerContext> initializer)
          : base(dbConnection, initializer, null)
        {
            this.ConfigureAuditing(AuditDbContextConfiguration);
            this.RegisterAuditTypes();
        }

        public PurchaseTrackerContext(IDbConnection dbConnection, Action<string> log)
           : base(dbConnection, null, log)
        {
            this.ConfigureAuditing(AuditDbContextConfiguration);
            this.RegisterAuditTypes();
        }

        public PurchaseTrackerContext(IDbConnection dbConnection, IDatabaseInitializer<PurchaseTrackerContext> initializer, Action<string> log = null)
           : base(dbConnection, initializer, log)
        {
            this.ConfigureAuditing(AuditDbContextConfiguration);
            this.RegisterAuditTypes();
        }

        private void RegisterAuditTypes()
        {
            var auditTypeInfo = new AuditTypeInfo(typeof(Category), typeof(CategoryAudit));
            this.RegisterAuditType(auditTypeInfo);

            auditTypeInfo = new AuditTypeInfo(typeof(Transaction), typeof(TransactionAudit));
            this.RegisterAuditType(auditTypeInfo);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Database.KillConnectionsToTheDatabase();

            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CategoryAuditConfiguration());
            modelBuilder.Configurations.Add(new TransactionConfiguration());
            modelBuilder.Configurations.Add(new TransactionAuditConfiguration());
        }
    }
}
