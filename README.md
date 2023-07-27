#CSharp USSD App

##Setup

###Step 1
After cloning or downloading repository create an MSSQL database then change the database connection credentials in appsettings.json ConnectionStrings.USSDConnection

###Step 2
Run SessionsTable.sql located in the root of the application to create the Sessions table in your MSSQL database

###Step 3
Import the file named 'CS USSD.postman_collection.json' into Postman or use the USSD simulator at https://simussd.interpayafrica.com/ to test the application
Ussd menus would be programmed in file USSDCSharp\USSDCSharp\UssdMenu.cs
