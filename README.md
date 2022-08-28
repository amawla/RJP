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
  
  
What the app contains and how to test it?
First of all it's about 5 pages 3 of them are listings (List of Customers, List of Accounts and List of Transactions). The rest 2 page are (Transaction Details page) 
and (Home page) which handles a form for filling customer info with initial credit.
To test the complete flow we have to follow these steps:
1. We considered that already 2 customers are inserted to our Database, therefore we can check the list of customers throught the nav menu on the left (Customers).
2. if we opened the home page we will find the form that we mention previously, this form contains the customers list filled in a dropdown, then we have the balance as
textbox to enter the amount which will represent the initial credit.
3. When we select a certain customer, our code behind will check if this current customer already have an account or we have to open a new one. How it will be?
4. If the customer don't have an account after filling the balance and saving, by default there will be a record inserted into the Accounts table with this customer id representing that we have opened a new account for him, also if the initial credit is not 0 there wil be a transaction sent to this account, listing what is this transaction for in addition to the details listed (Balance, Date, etc...)
5. If the customer already have an account opened, then another dropdown will be displayed holding the Transaction type if (Withdrawal or Deposit). This step is an addition to the requirements needed.
6. Here the customer can also process many transactions by choosing the type and entering the amount needed, which definitely will create a new transaction and send to the current account, the same will be listing the target of this transaction and the details it contains.
7. If we opened the Accounts page we will see the list of all Accounts, for each account we can view it's  by clicking the view button which will redirect us to the transactions page refered to this account.
8. Again if we opened the Transactions page we will see also the list of all transactions or the transaction for a certain account, here we have the option to click on the details button which will open a new page called Details for the current Transaction.


Structure used:
Regarding the backend, .Net Core is used with EntityFramework
Frontend: WebApi controllers are used with razor and ajax calls as a simple frontend structure.
