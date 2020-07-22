# Async-Inn

*Author: Andrew Smith*

- Lab-11
- Lab-12

---

### Description 

This is an ASP.NET Core Web Application that simulates a hotel chain. The ERD below displays
the current state of the database. An API is also integrated amongst the project in an *MVC*
fashion. Currently, there is only a handful of data residing in the database which was 
generated from the initial *seed data* in a *code first migration* approach.

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

### Change Log

- 1.4 Add controllers for all models into Controllers folder - 21 Jul 2020
- 1.3 Add seed data and add to migrations - 21 Jul 2020
- 1.2 Set up API - 21 Jul 2020
- 1.1 Hotel, Room and Amenities to Model folder - 21 Jul 2020
- 1.0 Add ERD into README.MD - 21 Jul 2020
    

