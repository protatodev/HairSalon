# Hair Salon

#### Epicodus C# Week 3 Hair Salon Project, 7.13.2018

#### By Protatodev (Thad Donaghue)

## Description

This website was written using C# .Net Core. The website demonstrates a simple Hair Salon admin portal. The employee can manage stylists and clients and can manipulate, add and delete each as necessary. All records are saved on a database using MySQL allowing for simple access.

## Specs

| Behavior | Input | Output | Why |
|----------|-------|--------|-----|
| Make basic splash page with buttons allowing the user to click to navigate | *No input* | *No output* | Very simple basic view created with a Home controller to setup a default landing page. Simple to implement |
| User clicks 'View Stylists' button and a new page is displayed with all of the salon's current stylists listed | *None* | *Page displaying stylists* | Simple page that retrieves the stylists from the database |
| User clicks 'View Clients' button and a new page is displayed with all of the salon's current clients listed | *None* | *Page displaying clients* | Simple page that retrieves the clients from the database |
| User clicks 'Add Stylist' button and a new page is displayed with a form to add a new stylist | *Name* *Experience* | *Adds the entry to the database and displays the page of all stylists* | Simple input gathering page for adding stylists |
| User clicks 'Add Client' button and a new page is displayed with a form to add a new client | *Name* *Stylist* | *Adds the entry to the database and displays the page of all clients* | Simple input gathering page for adding clients |
| Add form validation | *No input received in required field* | *Must fill out this field* | Moderately difficult to implement |
| Add functionality to update a stylist record | *Edit name and/or experience* | *Updates shown in new page* | Moderately difficult to implement |
| Add functionality to update a client record | *Edit name and/or stylist* | *Updates shown in new page* | Moderately difficult to implement |
| Add functionality to delete a client record | *Click Delete* | *Database updated* | Moderately difficult to implement |
| Add functionality to delete a stylist record | *Click Delete* | *Database updated* | Moderately difficult to implement |
| Add Details page for clients that shows various information and current stylists they are assigned to | *None* | *Details page* | Difficult to implement |
| Add Details page for stylists that shows various information and current clients they are serving | *None* | *Details page* | Difficult to implement |

## Setup on OSX / Windows

* Download and install .Net Core 1.1.4 (Linked below)
* Download and install Mono (Linked below)
* Clone the repo
* Run `dotnet restore` from within the project directory using PowerShell / Terminal

## Steps required to implement database (Command Line)

* From the command line, enter the following commands: 
* `> mysql -uroot -proot`
* `> CREATE DATABASE thad_donaghue;`
* `> USE thad_donaghue;`
* `> CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), experience INT, client_id INT);`
* `> CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);`

## Steps required to implement database (Import)

* From the cloned repository folder on your machine, locate the `.sql` file that is contained in the root folder
* Import the `.sql` file via your web server

## Testing Program Functionality (Command Line)

* Navigate to the cloned repository on your hard drive
* Navigate to the Model or Controller you wish to test
* Run `dotnet test` from within the directory

## Testing Program Functionality (Visual Studio)

* Navigate to the cloned repository on your hard drive
* Open the solution file in Visual Studio
* In the menu bar navigate to 'Test' => 'Run' => 'All Tests'
* Results will display in the test explorer

## Contribution Requirements

1. Clone the repo
1. Make a new branch
1. Commit and push your changes
1. Create a PR

## Technologies Used

* .Net Core 1.1.4
* MSTest
* CSS
* HTML
* Bootstrap 4.1.1
* MySQL
* MVC
* Razor

## Links

* https://github.com/protatodev/WordCounter
* https://github.com/dotnet/core/blob/master/release-notes/download-archives/1.1.4-download.md
* https://www.mono-project.com/

## License

This software is licensed under the MIT license.

Copyright (c) 2018 **Protatodev**