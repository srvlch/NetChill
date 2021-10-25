# NetChill

How to Setup

Please follow the steps for Initial Setup:
• Setting Connection String -  Firstly Open MVC application (NetChill -> NetChill.sln) and Right click on Netchill.PL and click “Set as StartUp Project”
o	Go to NetChill.PL -> Web.config and Replace (YOUR SERVER NAME) with your SQL Server Name in connection string named “NetChillConnectionString” (Line No. 29).                       ex- RAMESH\SQLEXPRESS.
o	Now, Go to NetChill.DAL -> App.config and Replace (YOUR SERVER NAME) with your SQL Server Name in connection string named “NetChillConnectionString” (Line No. 16). ex- RAMESH\SQLEXPRESS.
o	Database name used is “NetChill”, change database name in both connection string, if required.
o	No need of migration since auto migrations are enable. 
o	Build and Run project using F5 and minimize.

• Installing node modules-
o	Make sure , Angular is installed in machine. If not , run command “npm i -g @angular/cli” to install Angular globally.
o	Right Click on NetChill -> open with Visual Code -> Go to Terminal and run command
“npm install” or “npm i”. Wait till libraries to install.
o	After Installing, run the command “ng serve --open” and open http://localhost:4200/ .(make sure VS project is running).

• DB Setup-
o	As this is just demo project. You have to make DB structure as follows with some initial data.
![alt text](https://i.ibb.co/XDjWwZh/Untitled2.png)
 

• Firebase setup-
o	Since I am using firebase for video upload, we need Firebase config in NetChillUI\src\environments\environment.ts. So make sure to add suitable config.

Make sure you have active Internet Connection.


Thanks and Regards,
Saurav Loach




