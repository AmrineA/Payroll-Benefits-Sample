# Payroll-Benefits-Sample
An application demonstrating a simple payroll and benefits system

This application uses the following technologies and frameworks:
ASP.NET/.NET Core 2.0
Entity Framework Core
Angular 5
SQL Server 
C#
Bootstrap
TypeScript

Steps to run the application:
1. Ensure you have SQL Server LocalDB running, or modify the connection string in the appsettings.json file to point to an instance of SQL Server.
	-The SQL user will need permission to create the database in SQL Server, OR
	-The database will need to be created manually and the SQL user will need permission to create the tables in the database
2. Open a command line in the PayrollBenefits.Web project folder and run the following commands
	npm install
	webpack --config webpack.config.vendor.js
3. Run the application through Visual Studio (with PayrollBenefits.Web set as the startup project)