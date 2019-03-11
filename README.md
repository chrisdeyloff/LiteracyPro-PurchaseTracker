# PurchaseTracker
Main frameworks used 
- .Net 4.7.2
- EntityFramework
- EntityFramework.Toolkit
- Kendo UI Core
- Autofac

### Create Database
Use the following command to create the PurchaseTracker database:
- change the connection string according to your system

    PM> Update-Database -Verbose -ConnectionString "Server=localhost\SQLEXPRESS;Database=PurchaseTracker;Trusted_Connection=True;" -ConnectionProviderName "System.Data.SqlClient" -StartupProjectName PurchaseTracker.DataAccess -ProjectName PurchaseTracker.DataAccess

### NOTES:
- EntityFramework.Toolkit provides entity auditing. Query TransactionAudit to view auditing for transactions.
- Utilized Autofac for dependency injection
- Connection string is in web.config
