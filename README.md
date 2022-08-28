# RJP
Steps to launch the Project
Notice: Because our project is already migrated and updated with the database using SQL Server, the first step is to remove all migrations that are found in
the Migrations folder under RJP Layer. Go to Package Manager Console and type "remove-migrations".
The second step is to change the connection string found in appsettings.json file using the targeted SQL Server Credentials as follow:
 "ConnectionStrings": {
    "DefaultConnection": "Data Source=.;Initial Catalog=RJP;User ID=sa;Password=sa"
  },
  The third step is to add new migrations in Package Manager Console ex: add-migration "my first commit" and then when migration is done we have to update the database
  by typing Update-Database.
  
