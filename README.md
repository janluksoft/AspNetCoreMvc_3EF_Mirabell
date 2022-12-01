# ASP.NET Core MVC 3 Mirabell

C# ASP.NET Core MVC project with EF. App is used to manage employee tasks.

## About the project
- The application is called Mirabell and is used to manage employee tasks;
- It is website application project 3; 
- Website app works in ASP.NET Core MVC technology with Entity Framework;
- The data is stored in MS SQL data base;
- You can do CRUD operations on the Employees table and the Tasks table. The tables are linked;
- Partial views were also used;
- Application works on asynchronous operations.

![](/Jpg/AspNetCoreMvcEF3Mirabell.png)

## Working Mirabell app on cloud hosting

You can see Mirabell app running on [cloud hosting]( http://janluk-001-site1.dtempurl.com/Mirabell). 
Logged in users can perform all operations. Others can view the data.

## How does the application work?

The project has a main data class: [CompanyDBContext : DbContext]. This class contains two lists: DbSet<Employee>, DbSet<CTask>. On these lists, the application performs CRUD operations, and controllers through the Entity Framework save changes in the lists to the MS SQL database.
The project has three controllers, several view pages  .cshtml, css style libraries and JavaScript libraries. So that the html pages have a similar layout, added _Layout.cshtml page. This file defines the backbone of all pages.

## JavaScript

Actions on html pages are controlled by JavaScript functions grouped into two classes: [CDropDownOperations] and [CStatus]. They perform the following tasks:

- handle events from html controls;
- populate DropDown controls;
- they control the logic of choices;
- control line skips (accordion);
- initiate partial view reload;
- initiate the display of a modal form;


## About ASP.NET Core MVC

ASP.NET Core MVC is a rich framework for building web apps and APIs using the Model-View-Controller design pattern.

The Model-View-Controller (MVC) architectural pattern separates an application into three main groups of components: Models, Views, and Controllers. This pattern helps to achieve separation of concerns. Using this pattern, user requests are routed to a Controller which is responsible for working with the Model to perform user actions and/or retrieve results of queries. The Controller chooses the View to display to the user, and provides it with any Model data it requires.

![](/Jpg/MVC_block03.png)

Above shows the diagram the three main components and which ones reference the others.

## Details

- Environment: VS2019
- Target: .NET5 (Core)
- Output type: Web Application
- ASP.NET Core MVC



