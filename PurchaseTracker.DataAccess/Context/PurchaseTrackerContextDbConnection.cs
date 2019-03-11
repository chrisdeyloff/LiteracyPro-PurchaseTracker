using System;
using EntityFramework.Toolkit;
using System.Configuration;

namespace PurchaseTracker.DataAccess.Context
{
    /// <summary>
    /// This DbConnection implementation provides a ConnectionString for production.
    /// You can receive the production ConnectionString from an application configuration (app.config) if you like.
    /// </summary>
    public class PurchaseTrackerContextDbConnection : DbConnection
    {
        public PurchaseTrackerContextDbConnection()
            : base(name: "PurchaseTracker",
                   connectionString: ConfigurationManager.ConnectionStrings["PurchaseTracker"].ConnectionString
                   //connectionString: @"Server=localhost\SQLEXPRESS;Database=PurchaseTracker;Trusted_Connection=True;"
                )
        {
            this.LazyLoadingEnabled = false;
            this.ProxyCreationEnabled = false;
        }
    }
}