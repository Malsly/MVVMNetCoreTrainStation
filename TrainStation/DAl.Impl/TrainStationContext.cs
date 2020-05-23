using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Impl
{
    public class TrainStationContext : DbContext
    {
        public TrainStationContext(DbContextOptions<TrainStationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Van> Vans { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<RoutePropereties> RoutePropereties { get; set; }
        public DbSet<Passanger> Passangers { get; set; }
        public DbSet<ClassPropereties> ClassPropereties { get; set; }
    }
}
