using Microsoft.EntityFrameworkCore;
using RailWayModelLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayInfrastructureLibrary.Data
{
    public class RailWayDbContext : DbContext
    {
        public RailWayDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BookedTrip> BookedTrips { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Train> Trains { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
