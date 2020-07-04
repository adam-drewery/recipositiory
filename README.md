# The Recipositiory
##### An API for storage and retrieval of all the world's culinary recipes.

---
I've decided to use an onion architectural style for this API as I'm a big fan of it and feel it lends itself well to code reuse.
The project structure is as follows:

- *Domain*: Contains domain entities and their related logic.
- *Api*: ASP.NET WebAPI stuff.
- *Entities*: Entity Framework Repositories. (I would have called it repositories if it didn't sound so similar to the parent solution).  

#### Design Decisions

- I chose to back my repositories with SQLite because I developed this on linux and I don't have SQL Server set up.
