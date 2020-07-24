# Async-Inn

*Author: Andrew Smith*

- Lab-11
- Lab-12
- Lab-13

---

### Description 

This is an ASP.NET Core Web Application that simulates a hotel chain. The ERD below displays
the current state of the database. An API is also integrated amongst the project in an *MVC*
fashion. Currently, there is only a handful of data residing in the database which was 
generated from the initial *seed data* in a *code first migration* approach.

---

### Architecture -> Repository Design Pattern

The **repository design pattern** follows the **SOLID** principles 
([more info](https://www.telerik.com/blogs/30-days-of-tdd-day-five-make-your-code-solid)). In short, this
means that the code base responsibilities are compartmentalized, or *loosely coupled* so that everything
is not dependent on each other. 

This approach is achieved within this web application by creating separate *interfaces* and *file repositories* for each
model. Dependency injection services for all file repositories are then added within the 'startup' file.

---

### ERD

This ERD was taken from the 401 .NET course [repository](https://github.com/codefellows/seattle-dotnet-401d11).


![ERD](Assets/ERD.png)


**ERD Components:**

**Hotel Table**
- Keys
  - ID(PK)

**HotelRoom Table**
- Keys
  - HotelID(FK, CK)
  - RoomNumber(CK)
  - RoomID(FK)

**Room Table**
- Keys
  - ID(PK)

**RoomAmenities Table**
- Keys
  - AmenitiesID(FK, CK)
  - RoomID(FK, CK)

**Amenities Table**
- Keys
  - ID(PK)

---

### Languages / Tools

- C#
- ASP.NET Core
- EF (entity framework) Core

---

### Change Log

- 1.10 Add IHotelRoom interface - 23 Jul 2020
- 1.9 Add HotelRoom repo file - 23 Jul 2020
- 1.8 Add RoomAmenities & HotelRoom models - 23 Jul 2020
- 1.7 Add dependency injection services for all file repositories - 22 Jul 2020
- 1.6 Add file repositories for all models - 22 Jul 2020
- 1.5 Add Interfaces for all models - 22 Jul 2020
- 1.4 Add controllers for all models into Controllers folder - 21 Jul 2020
- 1.3 Add seed data and add to migrations - 21 Jul 2020
- 1.2 Set up API - 21 Jul 2020
- 1.1 Hotel, Room and Amenities to Model folder - 21 Jul 2020
- 1.0 Add ERD to README.MD - 21 Jul 2020
    

