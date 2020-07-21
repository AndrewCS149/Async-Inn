using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuiler)
        {
            modelBuiler.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Good Feels Inn",
                    StreetAddress = "12345 Road Street",
                    City = "Seattle",
                    State = "WA",
                    Phone = "12345678"
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Nice Stay Lounge",
                    StreetAddress = "12345 Road Street",
                    City = "Rockford",
                    State = "IL",
                    Phone = "12345678"
                }
            );
        }
    }
}
