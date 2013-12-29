# What is this example ?
In this example demonstrate how to use the DotNetAge database as main DB.

#Challenges
1. When you want to use the DotNetAge default database in module project you will
get a migrations exception from EF.
2. You want to use EF to access the tables that extended in DotNetAge default database.

#How to shared thd default database between DotNetAge and modules ?
Following  the steps below:

1. Create your DbContext class and set same connection name in constructor default is "DNADB"
2. Add your tables to the DotNetAge installed database by manual
3. Open web.config of DotNetAge and find the "AutoMigration" setting in appSettings section and set to "False" (Requried DotNetAge 3.1.1)
4. In your module registeration class override the OnAppStart method and set the data context Initializer to null.For example :             Database.SetInitializer&lt;TDbContext&gt;(null);

#How to use this example
1. Build the SharedContextTest project to DotNetAge/content/modules/[module-folder]
2. Run the product.sql file in your SQL Server



