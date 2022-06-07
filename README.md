# Clean Architecture Sample
### Project made after reading the book "Clean Architecture"

### This project is made with:

* ASP.NET Core MVC 6.0
* XUnit - Unit Tests
* Command Pattern
* DI
* Dependency Injection
* Rich domain
* EF Core and SQL Server
* Auto Mapper

### And, contains the principles presented by Uncle Bob on "Clean Architecture", like:
* Entities Layer
* Use cases layer
* Adapters layer
* Infrastructure layer
* Dependency rule

When I design this project, I started to design and think about the entities, use cases and the business first. After that, I coded all rules, validations and use cases. Later, I decided to use a MVC approach with ASP.NET Core MVC, EF Core as the project ORM, and all the little things about the frameworks and details. This approach is encouraged by Uncle Bob on the book. We have to think about the use cases, entities and business first, and after all that, we can think about the database, framework or web.

## What does this project do?
* Simple todo app
* Add todo
* See your todo list
* Delete todos
* Finish or reopen one todo
* See details of a todo
