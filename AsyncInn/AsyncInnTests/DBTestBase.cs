using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AsyncInnTests
{
    public class DBTestBase : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly IHotel _hotel;
        protected readonly IHotelRoom _hotelRoom;
        protected readonly IRoom _room;
        protected readonly IAmenities _amenities;
        protected readonly AsyncInnDbContext _db;

        public DBTestBase()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseSqlite(_connection)
                .Options);

            _db.Database.EnsureCreated();

            _hotel = new HotelRepo(_db, _hotelRoom);
            _hotelRoom = new HotelRoomRepo(_db, _room);
            _room = new RoomRepo(_db, _amenities);
            _amenities = new AmenitiesRepo(_db);
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}