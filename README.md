Project Name :CSVProcessor
Description :
CSVProcessor is a .NET Console application designed to handle large CSV files by processing data in blocks using multithreading for improved efficiency. The application reads records from a CSV file, processes them, and saves the results to a PostgreSQL database. It includes email validation and logs progress and errors using the NLog library.

The key functionalities include:
   1.Block-based processing to handle large files 
   2.Multithreading to speed up data processing.
   3.Validation of email addresses and storage of results in a PostgreSQL database.
   4.Logging of processing progress and errors to a file.
   
Installation :
1..NET 5.0 or later
2.PostgreSQL installed and configured
3.A CSV file with the following columns: id, name, age, email

Libraries Used :
1.CsvHelper for CSV file reading and parsing
2.Npgsql for PostgreSQL database connectivity
3.NLog for logging
4.XUnit for unit testing
Use below commands to install package:
dotnet add package CsvHelper
dotnet add package Npgsql
dotnet add package NLog
dotnet add package Xunit

Setup PostgreSQL Database :
Create the database in SQL tool and create new table with some parameter.
Create an appsettings.json file in the project root directory and add your database credentials 

Logger details:
Create an nlog.config file in the project root to specify logging settings

create the CSV file with .csv extention in your root directory of the project

Process Flow :
Program.cs: The main entry point for the application.
CsvProcessor.cs: Manages reading, processing, and batch handling of CSV data using multithreading.
DatabaseService.cs: Handles interactions with the PostgreSQL database.
EmailValidator.cs: Contains logic for validating email addresses.
LoggingService.cs: Configures and handles logging operations using NLog.
Models/CsvRecord.cs: Defines the data model for records processed from the CSV file.
UnitTests/: Contains unit tests to ensure the accuracy and stability of critical functions.

The data processing tasks involve:
Extracting the first letter of the name and concatenating it with the ID to create a Code field.
Validating the email addresses using .NET's System.Net.Mail.MailAddress class.

Finally build and run the project.

we can able to get the log files to read the information about the process flow.

