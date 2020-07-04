# The Recipositiory
##### An API for storage and retrieval of all the world's culinary recipes.

---
I've decided to use an onion architectural style for this API as I'm a big fan of it and feel it lends itself well to code reuse.
The project structure is as follows:

- *Domain*: Contains domain entities and their related logic.
- *Api*: ASP.NET WebAPI stuff. (The application layer).
- *Entities*: Entity Framework Repositories. (I would have called it repositories if it didn't sound so similar to the parent solution).
- *Api.Client*: C# client libraries for communicating with the API.
- *Api.Models*: Model classes used by both the API and client library.
- *Api.Tests*: Unit tests for controllers.  

#### Design Decisions

- I chose to back my repositories with `SQLite` because I developed this on linux and I don't have SQL Server set up. It should be painless to change though.
- I decided to use `Serilog` instead of `Microsoft.Extensions.Logging` because it has more features such as destructuring. I also chose not to DI my loggers because from my experience logging console output in tests can be useful.
- I applied some simple domain-oriented interfaces such as `INamed" so in future I can write extension methods for any entity or collections of entities that have that interface.  
- To seed the initial list of countries I used a library I wrote and published at my last role: `Audacia.Locality`.
- Tests are written using xUnit and FluentAssertions, and follow the structure described in this [blog post by Phil Haack](https://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/).
- To maintain a historical record of recipes, each update is saved as a new recipe, with a reference to the recipe it is based on.
- Entities with the `IAuditable` interface automatically have their CreatedDate set when saving (the DbContext handles this).
- I generated the documentation with Swagger. Its my first time using it actually, i followed [this guide](https://www.meziantou.net/how-to-document-an-asp-net-core-web-api-using-openapi-specification-swagger.htm)
- I considered using NSwag to generate client libraries but I haven't used it before so went with the safer option of manually writing it.

#### Things I didn't have time to finish

- Identity Server: Its set up but I ran out of time so there are no users or roles. The API client also has no functionality for authenticating.
- Validation: None of the models or entities are validated. For this I'd probably use [FluentValidation](https://fluentvalidation.net/) and [ASP.NET Core Model Validation](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1) (they work well together).
- Exception handling: Generally I find it useful to catch certain exceptions (like a ValidationException, and return a custom response to the client).
- Some sort of front-end: at least to test the API client library.
