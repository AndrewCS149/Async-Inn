# Async Inn

*Author: Andrew Smith*

- Lab-11
- Lab-12
- Lab-13
- Lab-14
- Lab-15
- Lab-17
- Lab-18 

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

### Authorization Levels

#### *District Managers*

District managers have full control over the database with the abilty of adding and removing entire hotels or amenities
and everything in between. District managers can also register new district managers, property managers and agents.

#### *Property Managers*

Property managers have the ability to add, update, and get hotel rooms and amenities. They also are able to register 
new agents.

#### *Agents*

Agents can only read and update a hotel room, and add and delete amenities from rooms.

---

### Routes 

**AmenitiesController**
- GetAmenity: `api/Amenities/{id}`
- GetAmenities: `api/Amenities`
- PutAmenities: `api/{id}`
- PostAmenity: `api/Amenities`
- DeleteAmenities: `api/Amenities/{id}`

**HotelRoomController**
- GetAllHotelRooms: `api/Hotels/Rooms`
- GetAllRoomsAtHotel: `api/Hotels/{hotelId}/Rooms`
- GetHotelRoom: `api/Hotels/{hotelId}/Rooms/{roomNumber}`
- PutHotelRoom: `api/Hotels/{hotelId}/Rooms/roomNumber}`
- PostHotelRoom: `api/Hotels/{hotelId}/Rooms`
- DeleteHotelRoom: `api/Hotels/{hotelId}/Rooms/{roomNum}`

**HotelsController**
- GetAllHotels: `api/Hotels/`
- GetHotel: `api/Hotels/{hotelId}`
- PutHotel: `api/Hotels/{hotelId}`
- PostHotel: `api/Hotels`
- DeleteHotel: `api/Hotels/{hotelId}`

**RoomsController**
- GetAllRooms: `api/Rooms`
- GetRoom: `api/Rooms/{roomId}`
- PutRoom: `api/Rooms/{roomId}`
- PostRoom: `api/Rooms`
- AddAmenityToRoom: `api/Rooms/{roomId}/Amenity/{amenityId}`
- RemoveAmenityFromRoom: `api/Rooms/{roomId}/Amenity/{amenityid}`
- DeleteRoom: `api/Rooms/{roomId}`

**AccountController**
- Register: `api/Account/Register`
- Login: `api/Account/Login`

---

### ASP.NET Core Identity

ASP.NET Core Identity is a package within ASP.Net Core that allows for managing users, 
creating passwords, user authentication and more.

---

### Languages / Tools

- C#
- ASP.NET Core
- EF (entity framework) Core

---

### Change Log

- 1.21 Authorizations set to all routes - 1 Aug 2020
- 1.20 'District Manager', 'Property Manager' & 'Agent' - 1 Aug 2020
- 1.19 User authentication and authorization - 1 Aug 2020
- 1.18 All routes working as intended - 31 Jul 2020
- 1.17 Add AppUser controller and add routes - 28 Jul 2020
- 1.16 Add UserApp class - 28 Jul 2020
- 1.15 Modify all hotel methods into DTO - 27 Jul 2020
- 1.14 Modify all hotelRoom methods into DTO - 27 Jul 2020
- 1.13 Modify all room methods into DTO - 27 Jul 2020
- 1.12 Modify all amenities methods into DTO - 27 Jul 2020
- 1.11 AmenitiesExists() - 27 Jul 2020
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
    

