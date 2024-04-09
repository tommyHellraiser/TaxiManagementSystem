# Taxi Management System
It's a small and simple system to manage car assignments to drivers, departures, car rental for drivers, and simple balance tracking.

Designed and coded in C#, and based on a SQL Server database

## Setup
Only configure the json file in `config/config.json`, set "DataSource" as the name of the SQL instance, and and "InitialCatalog" as the name of the database. 

The rest of the parameters are internal configurations for fees, car assembly dates, and balance debt limitations.

Once config.json has been set up, open the `.sln` solution to compile the project, as build or release, your choice. Once it's done, just run the exe (if compiled on Release) or run te debugger (if compiled on Debug), and you're good to go!

## Bugs reporting
If you encounter any bugs, please fee free to contact me and report them, at:
`nacho.ponce25@gmail.com` or on Telegram `tommyHellraiser`
